/* ----------------------------------------------------------------------- *

    * InputModifiers.cs

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

public class InputModifiers
{
  static void Main()
  {
    foreach(var d in SimIO.inputDevices.Where(d => d.isKindOf<RawInputHID>()).Select(d => d as RawInputHID)) {
      Console.WriteLine(d.productString);
    }

    var iKeyboard = new Keyboard.InputDeviceWrapper();
    var iJoystick = new Joystick.InputDeviceWrapper(d => (d as RawInputHID).productString == "Saitek X52 Flight Control System");
    // var iJoystick = new Joystick.InputDeviceWrapper();
    var iMouse = new Mouse.InputDeviceWrapper();

    // Axis value is normalized between 0 and 1
    var normalized = iJoystick.x.normalized();

    // Makes axis bidirectional.
    // Eg : an axis with minimumValue : 0, and maximumVaue : 2048 will become minimumValue : -1024, maximumValue : 1024
    var bidi = iJoystick.x.bidirectional();

    // Makes a normalized bidirectional axis. Eg: axis values will be between -1 and 1
    var bidiNormalized = iJoystick.x.normalizedBidirectional();

    // Sets a deadzone at start of the axis
    var deadzoneAtStart = iJoystick.x.normalized().deadzone(0, 0.25f);

    // Sets a deadzone at the end of the axis
    var deadzoneAtEnd = iJoystick.x.normalized().deadzone(0.75f, 1.0f);

    // Sets a deadzone at the middle of the axis
    var deadzone = iJoystick.x.normalized().deadzone(0.25f, 0.75f);

    // Makes a custom modifier
    var custom = iJoystick.x.functionalModifier(p => p.value * 2, minimumValue : -2, maximumValue : 2);

    // Makes a button modifier. The "button" will be considered down between given values
    var button = iJoystick.x.normalized().button(0.5f, 1.0f);

    if (button.isDown) {
      // ... do something
    }

    if (button.isDown) {
      // ... do something
    }

    if (button.isReleased) {
      // ... do something
    }


    var splitOne = iJoystick.x.normalized().splitAxis(0.25f, 0.5f);
    var splitTwo = iJoystick.x.normalized().splitAxis(0.5f, 0.75f);

    var escapeKey = iKeyboard.escape.button();

    while(!escapeKey.isDown) {
      SimIO.update();

      Console.WriteLine(splitOne.value + " " + splitTwo.value);

      Thread.Sleep(250);
    }

    Console.WriteLine("Ok");
  }
}
