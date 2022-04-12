/* ----------------------------------------------------------------------- *

    * vJoyDevice.cs

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
using vJoyInterfaceWrap;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class vJoyDevice : OutputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal abstract class vJoyDeviceElement : OutputDevice.Element
  {
    // -----------------------------------------------------------------------
    public OutputDevice device {get; protected set;}
    public ElementIdentifier id {get; protected set;}

    public abstract bool isCyclic {get;}
    public abstract bool isRelative {get;}
    public abstract bool isAbsolute {get;}
    public abstract float minimumValue {get; protected set;}
    public abstract float maximumValue {get; protected set;}
    public abstract float value {get; set;}

    public bool isValid => true;

    protected vJoy v => (device as vJoyDevice).v;
    protected uint vid => (device as vJoyDevice).id;

    // -----------------------------------------------------------------------
    internal vJoyDeviceElement(OutputDevice device, ElementIdentifier id)
    {
      this.device = device;
      this.id = id;
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal class vJoyDeviceAxis : vJoyDeviceElement
  {
    public override bool isCyclic => false;
    public override bool isRelative => false;
    public override bool isAbsolute => true;

    public override float minimumValue {get; protected set;}
    public override float maximumValue {get; protected set;}
    HID_USAGES usage;
    float lastValue;

    // -----------------------------------------------------------------------
    public override float value
    {
      get => lastValue;
      set {
        v.SetAxis((int) (lastValue = value), vid, usage);
      }
    }

    // -----------------------------------------------------------------------
    internal vJoyDeviceAxis(OutputDevice device, ElementIdentifier id, HID_USAGES usage) : base(device, id)
    {
      this.usage = usage;
      {
        long min = 0;
        v.GetVJDAxisMin(vid, usage, ref min);
        minimumValue = min;
      }
      {
        long max = 0;
        v.GetVJDAxisMax(vid, usage, ref max);
        maximumValue = max;
      }
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal class vJoyDeviceButton : vJoyDeviceElement
  {
    public override bool isCyclic => false;
    public override bool isRelative => false;
    public override bool isAbsolute => true;

    public override float minimumValue {get; protected set;} = 0;
    public override float maximumValue {get; protected set;} = 1;

    uint button;
    float lastValue;

    // -----------------------------------------------------------------------
    public override float value
    {
      get => lastValue;
      set {
        v.SetBtn((lastValue = value) > 0 ? true : false, vid, button);
      }
    }

    // -----------------------------------------------------------------------
    internal vJoyDeviceButton(OutputDevice device, ElementIdentifier id, uint button) : base(device, id)
    {
      this.button = button;
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal class vJoyDeviceCPOV : vJoyDeviceElement
  {
    public override bool isCyclic => true;
    public override bool isRelative => false;
    public override bool isAbsolute => true;

    public override float minimumValue {get; protected set;} = 0;
    public override float maximumValue {get; protected set;} = 1;

    float lastValue;

    // -----------------------------------------------------------------------
    public override float value
    {
      get => lastValue;
      set {
        v.SetContPov(value < 0 ? -1 : (int) (lastValue = value * 35900), vid, 1);
      }
    }

    // -----------------------------------------------------------------------
    internal vJoyDeviceCPOV(OutputDevice device, ElementIdentifier id) : base(device, id)
    {
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal class vJoyDeviceDPOV : vJoyDeviceElement
  {
    public override bool isCyclic => true;
    public override bool isRelative => false;
    public override bool isAbsolute => true;

    public override float minimumValue {get; protected set;} = 0;
    public override float maximumValue {get; protected set;} = 1;

    float lastValue;

    // -----------------------------------------------------------------------
    public override float value
    {
      get => lastValue;
      set {
        v.SetDiscPov(value < 0 ? -1 : (int) (lastValue = value * 4), vid, 1);
      }
    }

    // -----------------------------------------------------------------------
    internal vJoyDeviceDPOV(OutputDevice device, ElementIdentifier id) : base(device, id)
    {
    }
  }

  // -------------------------------------------------------------------------
  static readonly Dictionary<HID_USAGES, ElementIdentifier> axisMap = new Dictionary<HID_USAGES, ElementIdentifier>() {
    {HID_USAGES.HID_USAGE_X, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.X, "X Axis")},
    {HID_USAGES.HID_USAGE_Y, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Y, "Y Axis")},
    {HID_USAGES.HID_USAGE_Z, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Z, "Z Axis")},
    {HID_USAGES.HID_USAGE_RX, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Rx, "X Rotation")},
    {HID_USAGES.HID_USAGE_RY, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Ry, "Y Rotation")},
    {HID_USAGES.HID_USAGE_RZ, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Rz, "Z Rotation")},
    {HID_USAGES.HID_USAGE_SL0, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Slider, "Slider")},
    {HID_USAGES.HID_USAGE_SL1, new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Dial, "Dial")},
  };

  // -------------------------------------------------------------------------
  protected vJoy v;
  protected uint id;
  internal vJoyDeviceElement[] _elements;

  // -------------------------------------------------------------------------
  public string deviceIdentifier => "vjoy:" + id;

  // -------------------------------------------------------------------------
  public Type deviceType => typeof(InputDevice.DeviceType.Joystick);

  // -------------------------------------------------------------------------
  public bool isAttached => true;

  // -------------------------------------------------------------------------
  public bool isActive {get; set;}

  // -------------------------------------------------------------------------
  public IEnumerable<OutputDevice.Element> elements => _elements;

  // -------------------------------------------------------------------------
  public event OutputDeviceAttachmentNotification attachmentNotification = delegate {};

  // -------------------------------------------------------------------------
  internal vJoyDevice(vJoy v, uint id)
  {
    this.v = v;
    this.id = id;

    List<vJoyDeviceElement> elements = new List<vJoyDeviceElement>();

    foreach(var axis in axisMap) {
      if (v.GetVJDAxisExist(id, axis.Key))
        elements.Add(new vJoyDeviceAxis(this, axis.Value, axis.Key));
    }

    for (uint i = 0, s = (uint) v.GetVJDButtonNumber(id); i < s; i++) {
      elements.Add(new vJoyDeviceButton(this, new HidIdentifier(typeof(ElementIdentifier.ElementType.Button), HidUsage.UsagePage.Button, (HidUsage.Usage) i, "Button " + i), i));
    }


    if (v.GetVJDContPovNumber(id) >= 1) {
      elements.Add(new vJoyDeviceCPOV(this, new HidIdentifier(typeof(ElementIdentifier.ElementType.POVHat), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.HatSwitch, "POV Hat")));
    }
    else if (v.GetVJDDiscPovNumber(id) >= 1) {
      elements.Add(new vJoyDeviceDPOV(this, new HidIdentifier(typeof(ElementIdentifier.ElementType.POVHat), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.HatSwitch, "POV Hat")));
    }

    _elements = elements.ToArray();
  }
}

} // End of namespace th.simio
