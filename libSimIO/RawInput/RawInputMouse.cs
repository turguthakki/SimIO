/* ----------------------------------------------------------------------- *

    * RawInputMouse.cs

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

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class RawInputMouse : RawInputDevice
{
  RawInputDeviceElement xPosition;
  RawInputDeviceElement yPosition;

  RawInputDeviceElement xAxis;
  RawInputDeviceElement yAxis;
  RawInputDeviceElement wheelX;
  RawInputDeviceElement wheelY;
  RawInputDeviceElement leftButton;
  RawInputDeviceElement rightButton;
  RawInputDeviceElement middleButton;
  RawInputDeviceElement forwardButton;
  RawInputDeviceElement backButton;

  // -------------------------------------------------------------------------
  internal RawInputMouse(IntPtr deviceHandle, string devicePath, RID_DEVICE_INFO deviceInfo) : base(deviceHandle, devicePath, deviceInfo)
  {
    deviceType = typeof(InputDevice.DeviceType.Mouse);
    List<RawInputDeviceElement> elements = new List<RawInputDeviceElement>() {
      (xPosition = new RawInputDeviceElement(this, Mouse.xPosition, true, 0, 0)),
      (yPosition = new RawInputDeviceElement(this, Mouse.yPosition, true, 0, 0)),
      (xAxis = new RawInputDeviceElement(this, Mouse.xAxis, false, 0, 0)),
      (yAxis = new RawInputDeviceElement(this, Mouse.yAxis, false, 0, 0)),
      (wheelX = new RawInputDeviceElement(this, Mouse.wheelX, false, 0, 0)),
      (wheelY = new RawInputDeviceElement(this, Mouse.wheelY, false, 0, 0)),
      (leftButton = new RawInputDeviceElement(this, Mouse.leftButton)),
      (rightButton = new RawInputDeviceElement(this, Mouse.rightButton)),
      (middleButton = new RawInputDeviceElement(this, Mouse.middleButton)),
      (forwardButton = new RawInputDeviceElement(this, Mouse.forwardButton)),
      (backButton = new RawInputDeviceElement(this, Mouse.backButton))
    };
    foreach(var elem in elements) {
      elem.onInput += (d, e) => notifyInput(d, e);
    }
    _elements = elements.ToArray();
  }

  // -------------------------------------------------------------------------
  internal unsafe override void update(RAWINPUT *data)
  {
    RAWMOUSE m = data->mouse;

    if ((m.usFlags & MOUSE_MOVE_RELATIVE) == MOUSE_MOVE_RELATIVE) {
      // https://stackoverflow.com/questions/36862013/raw-input-and-cursor-acceleration
      float x = m.lLastX;
      float y = m.lLastY;

      int speed = 0;
      int[] acceleration = new int[3];
      SystemParametersInfo(SPI_GETMOUSESPEED, 0, ((IntPtr) (&speed)), 0);
      fixed(int *pAcceleration = acceleration) {
        SystemParametersInfo(SPI_GETMOUSE, 0, (IntPtr) pAcceleration, 0);
      }

      if (acceleration[2] > 0 && acceleration[0] < Math.Abs(m.lLastX))
          x *= 2;
      else if (acceleration[2] > 1 && acceleration[1] < Math.Abs(m.lLastX))
          x *= 2;

      if (acceleration[2] > 0 && acceleration[0] < Math.Abs(m.lLastX))
          y *= 2;
      else if (acceleration[2] > 1 && acceleration[1] < Math.Abs(m.lLastX))
          y *= 2;

      x *= (float) Math.Round(speed / 10.0f);
      y *= (float) Math.Round(speed / 10.0f);

      xAxis.setRelativeData(x);
      yAxis.setRelativeData(y);
    }

    if ((m.usButtonFlags & RI_MOUSE_LEFT_BUTTON_DOWN) == RI_MOUSE_LEFT_BUTTON_DOWN)
      leftButton.setAbsoluteData(1);
    if ((m.usButtonFlags & RI_MOUSE_LEFT_BUTTON_UP) == RI_MOUSE_LEFT_BUTTON_UP)
      leftButton.setAbsoluteData(0);
    if ((m.usButtonFlags & RI_MOUSE_RIGHT_BUTTON_DOWN) == RI_MOUSE_RIGHT_BUTTON_DOWN)
      rightButton.setAbsoluteData(1);
    if ((m.usButtonFlags & RI_MOUSE_RIGHT_BUTTON_UP) == RI_MOUSE_RIGHT_BUTTON_UP)
      rightButton.setAbsoluteData(0);
    if ((m.usButtonFlags & RI_MOUSE_MIDDLE_BUTTON_DOWN) == RI_MOUSE_MIDDLE_BUTTON_DOWN)
      middleButton.setAbsoluteData(1);
    if ((m.usButtonFlags & RI_MOUSE_MIDDLE_BUTTON_UP) == RI_MOUSE_MIDDLE_BUTTON_UP)
      middleButton.setAbsoluteData(0);
    if ((m.usButtonFlags & RI_MOUSE_BUTTON_4_DOWN) == RI_MOUSE_BUTTON_4_DOWN)
      backButton.setAbsoluteData(1);
    if ((m.usButtonFlags & RI_MOUSE_BUTTON_4_UP) == RI_MOUSE_BUTTON_4_UP)
      backButton.setAbsoluteData(0);
    if ((m.usButtonFlags & RI_MOUSE_BUTTON_5_DOWN) == RI_MOUSE_BUTTON_5_DOWN)
      forwardButton.setAbsoluteData(1);
    if ((m.usButtonFlags & RI_MOUSE_BUTTON_5_UP) == RI_MOUSE_BUTTON_5_UP)
      forwardButton.setAbsoluteData(0);
    if ((m.usButtonFlags & RI_MOUSE_WHEEL) == RI_MOUSE_WHEEL)
      wheelY.setRelativeData(unchecked((Int16) m.usButtonData));
    if ((m.usButtonFlags & RI_MOUSE_HWHEEL) == RI_MOUSE_HWHEEL)
      wheelX.setRelativeData(unchecked((Int16) m.usButtonData));
  }
}

} // End of namespace th.simio
