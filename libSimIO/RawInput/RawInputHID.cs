/* ----------------------------------------------------------------------- *

    * RawInputHID.cs

    ----------------------------------------------------------------------

    Copyright (C) 2021, Turgut Hakki Ozdemir
    All Rights Reserved.

    THIS SOFTWARE IS PROVIDED 'AS-IS', WITHOUT ANY EXPRESS
    OR IMPLIED WARRANTY. IN NO EVENT WILL THE AUTHOR(S) BE HELD LIABLE FOR
    ANY DAMAGES ARISING FROM THE USE OR DISTRIBITION OF THIS SOFTWARE

    Permission is granted to anyone to use this software for any purpose,
    including commercial applications, and to alter it and redistribute it
    freely, subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not
       claim that you wrote the original software.
    2. Altered source versions must be plainly marked as such, and must not be
       misrepresented as being the original software.
    4. Distributions in binary form must reproduce the above copyright notice
       and an acknowledgment of use of this software either in documentation
       or binary form itself.
    3. This notice may not be removed or altered from any source distribution.

    Turgut Hakkı Özdemir <turgut.hakki@gmail.com>

* ------------------------------------------------------------------------ */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.Marshal;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class RawInputHID : RawInputDevice
{
  // -------------------------------------------------------------------------
  class Page
  {
    public HidUsage.Usage usageMin;
    public Dictionary<HidUsage.Usage, RawInputDeviceElement> elementsByUsage = new Dictionary<HidUsage.Usage, RawInputDeviceElement>();
  }

  // -------------------------------------------------------------------------
  class Buttons
  {
    public Dictionary<HidUsage.UsagePage, Page> pages = new Dictionary<HidUsage.UsagePage, Page>();
    public HidUsage.Usage[] usages;
  }

  Buttons buttons = new Buttons();
  Dictionary<HidUsage.UsagePage, Page> axes = new Dictionary<HidUsage.UsagePage, Page>();
  IntPtr preparsedData = IntPtr.Zero;

  HIDP_VALUE_CAPS[] valueCaps;

  // -------------------------------------------------------------------------
  unsafe internal RawInputHID(IntPtr deviceHandle, string devicePath, RID_DEVICE_INFO deviceInfo) : base(deviceHandle, devicePath, deviceInfo)
  {
    deviceType = deviceInfo.hid.usUsage == (UInt16) HidUsage.Usage.GamePad ? deviceType = typeof(InputDevice.DeviceType.Gamepad) : typeof(InputDevice.DeviceType.Joystick);
    List<RawInputDeviceElement> elements = new List<RawInputDeviceElement>();
    uint preparsedDataSize = 0;
    GetRawInputDeviceInfo(deviceHandle, RIDI_PREPARSEDDATA, IntPtr.Zero, ref preparsedDataSize);
    preparsedData = AllocHGlobal((int) preparsedDataSize);
    GetRawInputDeviceInfo(deviceHandle, RIDI_PREPARSEDDATA, preparsedData, ref preparsedDataSize);

    HIDP_CAPS capabilities = new HIDP_CAPS();
    HidP_GetCaps(preparsedData, ref capabilities);

    // Buttons
    {
      HIDP_BUTTON_CAPS[] buttonCaps = new HIDP_BUTTON_CAPS[capabilities.NumberInputButtonCaps];
      UInt16 buttonCapsCount = capabilities.NumberInputButtonCaps;
      fixed (HIDP_BUTTON_CAPS *bCaps = buttonCaps) {
        HidP_GetButtonCaps(Hid.HIDP_REPORT_TYPE.HidP_Input, bCaps, &buttonCapsCount, preparsedData);
      }

      for (int i = 0; i < buttonCapsCount; i++) {
        HIDP_BUTTON_CAPS bcaps = buttonCaps[i];
        Page page = null;

        if (bcaps.UsagePage != HidUsage.UsagePage.Button)
          continue;

        if (!buttons.pages.TryGetValue(bcaps.UsagePage, out page))
          buttons.pages.Add(bcaps.UsagePage, page = new Page());

        Action<HidUsage.UsagePage, HidUsage.Usage> addButton = (HidUsage.UsagePage usagePage, HidUsage.Usage usage) => {
          RawInputDeviceElement element = new RawInputDeviceElement(this, new HidIdentifier(typeof(ElementIdentifier.ElementType.Button), usagePage, usage, "button p" + usagePage.ToString("x") + "u" + usage.ToString("x")));
          page.elementsByUsage[usage] = element;
          elements.Add(element);
        };

        if (bcaps.IsRange) {
          page.usageMin = bcaps.Range.UsageMin;
          for (HidUsage.Usage usage = bcaps.Range.UsageMin; usage <= bcaps.Range.UsageMax; usage++) {
            addButton(bcaps.UsagePage, usage);
          }
        }
        else {
          page.usageMin = bcaps.NotRange.Usage;
          addButton(bcaps.UsagePage, bcaps.NotRange.Usage);
        }
      }

      int count = 0;
      foreach(var page in buttons.pages)
        count = Math.Max(count, page.Value.elementsByUsage.Count);
      buttons.usages = new HidUsage.Usage[count];
    }

    // Axes
    {
      valueCaps = new HIDP_VALUE_CAPS[capabilities.NumberInputValueCaps];
      UInt16 valueCapabilitiesCount = capabilities.NumberInputValueCaps;

      fixed(HIDP_VALUE_CAPS *vCaps = valueCaps) {
        HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Input, vCaps, ref valueCapabilitiesCount, preparsedData);
      }

      for (UInt16 vci = 0; vci < valueCapabilitiesCount; vci++) {
        HIDP_VALUE_CAPS vcaps = valueCaps[vci];
        Page page = null;

        switch(vcaps.UsagePage) {
          case HidUsage.UsagePage.GenericDesktop :
          case HidUsage.UsagePage.SimulationControls :
          case HidUsage.UsagePage.VrControls :
          case HidUsage.UsagePage.SportControls :
          case HidUsage.UsagePage.GameControls :
          case HidUsage.UsagePage.GenericDeviceControls :
          case HidUsage.UsagePage.Keyboard :
          case HidUsage.UsagePage.Led :
          case HidUsage.UsagePage.Button :
          case HidUsage.UsagePage.Ordinal :
          case HidUsage.UsagePage.Telephony :
          case HidUsage.UsagePage.Consumer :
          case HidUsage.UsagePage.Digitizers :
          case HidUsage.UsagePage.Unicode :
          case HidUsage.UsagePage.AlphanumericDisplay :
          case HidUsage.UsagePage.MedicalInstrument :
            break;
          default :
            continue;
        }

        if (!axes.TryGetValue(vcaps.UsagePage, out page))
          axes.Add(vcaps.UsagePage, page = new Page());

        Action<HidUsage.UsagePage, HidUsage.Usage> addAxis = (HidUsage.UsagePage usagePage, HidUsage.Usage usage) => {
          float minValue = 0;
          float maxValue = 0;
          bool isCyclic;
          bool isAbsolute;

          if (vcaps.LogicalMax < vcaps.LogicalMin) {
            if (vcaps.BitSize > 0) {
              minValue = 0;
              maxValue = (float) (1 << vcaps.BitSize);
            }
            else {
              // Don't know what to do with this
              // return;
            }
          }
          else {
            minValue = (float) vcaps.LogicalMin;
            maxValue = (float) vcaps.LogicalMax;
          }

          isCyclic = (vcaps.BitField & (1 << 3)) != 0;
          isAbsolute = ((vcaps.BitField & (1 << 2)) == (1 << 2)) || vcaps.IsAbsolute;

          RawInputDeviceElement.HIDValueHandler handler;

          if (minValue < 0) {
            handler = scaledValueHandler;
          }
          else {
            handler = valueHandler;
          }

          Type elementType = null;

          if (isAbsolute)
            elementType = typeof(ElementIdentifier.ElementType.AbsoluteAxis);
          else
            elementType = typeof(ElementIdentifier.ElementType.RelativeAxis);

          RawInputDeviceElement element = new RawInputDeviceElement(this,
            new HidIdentifier(elementType, usagePage, usage, "axis p" + usagePage.ToString("x") + "u" + usage.ToString("x")),
            isAbsolute,
            minValue < 0 ? -1 : 0,
            1,
            isCyclic
          );

          element.hidMinValue = minValue;
          element.hidMaxValue = maxValue;
          element.valueHandler = handler;

          page.elementsByUsage[usage] = element;
          elements.Add(element);
        };

        if (vcaps.IsRange) {
          page.usageMin = vcaps.Range.UsageMin;
          for (HidUsage.Usage usage = vcaps.Range.UsageMin; usage <= vcaps.Range.UsageMax; usage++) {
            addAxis(vcaps.UsagePage, usage);
          }
        }
        else {
          page.usageMin = vcaps.NotRange.Usage;
          addAxis(vcaps.UsagePage, vcaps.NotRange.Usage);
        }
      }

    }

    foreach(var elem in elements) {
      elem.onInput += (d, e) => notifyInput(d, e);
    }
    _elements = elements.ToArray();
  }

  // -------------------------------------------------------------------------
  ~RawInputHID()
  {
    FreeHGlobal(preparsedData);
  }

  // -------------------------------------------------------------------------
  static float InverseLerp(float a, float b, float v) => (v - a) / (b - a);

  // -------------------------------------------------------------------------
  static unsafe void valueHandler(RAWINPUT *data, RawInputDeviceElement axis)
  {
    UInt32 value = 0;
    HidP_GetUsageValue(HIDP_REPORT_TYPE.HidP_Input, axis.hidIdentifier.usagePage, 0, axis.hidIdentifier.usage, &value, (axis.device as RawInputHID).preparsedData, data->hid.bRawData, data->hid.dwSizeHid);

    float fValue = InverseLerp(axis.hidMinValue, axis.hidMaxValue, value);
    if (axis.isAbsolute)
      axis.setAbsoluteData(fValue, value >= axis.hidMinValue && value <= axis.hidMaxValue);
    else
      axis.setRelativeData(fValue, value >= axis.hidMinValue && value <= axis.hidMaxValue);
  }

  // -------------------------------------------------------------------------
  static unsafe void scaledValueHandler(RAWINPUT *data, RawInputDeviceElement axis)
  {
    Int32 value = 0;
    HidP_GetScaledUsageValue(HIDP_REPORT_TYPE.HidP_Input, axis.hidIdentifier.usagePage, 0, axis.hidIdentifier.usage, &value, (axis.device as RawInputHID).preparsedData, data->hid.bRawData, data->hid.dwSizeHid);

    float fValue = InverseLerp(axis.hidMinValue, axis.hidMaxValue, value);
    if (axis.isAbsolute)
      axis.setAbsoluteData(fValue, value >= axis.hidMinValue && value <= axis.hidMaxValue);
    else
      axis.setRelativeData(fValue, value >= axis.hidMinValue && value <= axis.hidMaxValue);
  }

  // -------------------------------------------------------------------------
  internal unsafe override void update(RAWINPUT *data)
  {
    foreach(var page in buttons.pages) {
      UInt32 usageLength = (UInt32) buttons.usages.Length;

      fixed(HidUsage.Usage *usages = buttons.usages) {
        HidP_GetUsages(HIDP_REPORT_TYPE.HidP_Input, page.Key, 0, (UInt16 *) usages, ref usageLength, preparsedData, data->hid.bRawData, data->hid.dwSizeHid);
      }

      foreach (var b in page.Value.elementsByUsage) {
        b.Value.tmpValue = false;
      }

      for (ulong u = 0; u < usageLength; u++) {
        RawInputDeviceElement elem = null;
        if (page.Value.elementsByUsage.TryGetValue(buttons.usages[u], out elem)) {
          elem.tmpValue = true;
        }
      }

      foreach (var b in page.Value.elementsByUsage) {
        b.Value.setAbsoluteData(b.Value.tmpValue ? 1.0f : 0.0f);
      }
    }

    foreach(var axis in axes.SelectMany(page => page.Value.elementsByUsage.Values).Where(e => e.valueHandler is not null)) {
      axis.valueHandler(data, axis);
    }
  }
}

} // End of namespace th.simio
