/* ----------------------------------------------------------------------- *

    * BasicUse.cs

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
using th.SimIO;
using th.SimIO.Selectors;

public class BasicUse
{
  static void Main()
  {
    var iJoystick = new Joystick.InputDeviceWrapper();
    var oMouse = new Mouse.OutputDeviceWrapper();
    var iKeyboard = new Keyboard.InputDeviceWrapper();
    var oKeyboard = new Keyboard.OutputDeviceWrapper();

    var xAxis = iJoystick.x.normalizedBidirectional();
    var yAxis = iJoystick.y.normalizedBidirectional();
    var escapeKey = iKeyboard.escape.button();

    while(!escapeKey.isDown) {
      SimIO.update();

      oKeyboard.w.value = yAxis.value < -0.5f ? 1 : 0;
      oKeyboard.s.value = yAxis.value > 0.5f ? 1 : 0;
      oKeyboard.a.value = xAxis.value < -0.5f ? 1 : 0;
      oKeyboard.d.value = xAxis.value > 0.5f ? 1 : 0;

      oKeyboard.leftshift.value = iJoystick.z.value < 0.5f ? 1.0f : 0.0f;
      oMouse.leftButton.value = iJoystick.button1.value;
      oMouse.rightButton.value = iJoystick.button2.value;

      Thread.Sleep(16);
    }

    Console.WriteLine("Ok");
  }
}
