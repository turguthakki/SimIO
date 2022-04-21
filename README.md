# SimIO

Programmable Input Emulator for C#. It's a simulation enthusiast's utility similar to [FreePIE](https://andersmalmgren.github.io/FreePIE/) and [GlovePIE](https://github.com/Ravbug/GlovePIE) but for C#.

## Features
Can read input from Keyboard, mouse or HID compatible devices via Rawinput and write Keyboard, mouse and joystick input using SendInput and [vJoy](http://vjoystick.sourceforge.net/joomla/).

## Limitations and requirements
 * Only works on Windows x64 platform.
 * [vJoy](http://vjoystick.sourceforge.net/joomla/) must be installed on the system.
 * Unlike GlovePIE and FreePIE SimIO does not provide any user interface or editor.


Code Example

``` csharp
using th.SimIO;
using th.SimIO.Helpers;

public class BasicUse
{
  static void Main()
  {
    var iJoystick = new Joystick.InputDeviceWrapper();
    var oMouse = new Mouse.OutputDeviceWrapper();
    var iKeyboard = new Keyboard.InputDeviceWrapper();
    var oKeyboard = new Keyboard.OutputDeviceWrapper();

    while(!iKeyboard.escape.isDown()) {
      SimIO.update();

      oKeyboard.w.value = iJoystick.y.bidiNormalizedPosition() < -0.5f ? 1 : 0;
      oKeyboard.s.value = iJoystick.y.bidiNormalizedPosition() > 0.5f ? 1 : 0;
      oKeyboard.a.value = iJoystick.x.bidiNormalizedPosition() < -0.5f ? 1 : 0;
      oKeyboard.d.value = iJoystick.x.bidiNormalizedPosition() > 0.5f ? 1 : 0;

      oKeyboard.leftshift.value = iJoystick.z.value < 0.5f ? 1.0f : 0.0f;
      oMouse.leftButton.value = iJoystick.button1.value;
      oMouse.rightButton.value = iJoystick.button2.value;

      Thread.Sleep(16);
    }

    Console.WriteLine("Ok");
  }
}
```