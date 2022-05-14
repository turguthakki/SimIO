# SimIO

Programmable Input Emulator for C#. It's a simulation enthusiast's utility similar to [FreePIE](https://andersmalmgren.github.io/FreePIE/) and [GlovePIE](https://github.com/Ravbug/GlovePIE) but for C#.

## Features
Can read input from Keyboard, mouse or HID compatible devices via Rawinput and write Keyboard, mouse and joystick input using SendInput and [vJoy](http://vjoystick.sourceforge.net/joomla/).

## Limitations and requirements
 * Only works on Windows x64 platform.
 * [vJoy](http://vjoystick.sourceforge.net/joomla/) must be installed on the system.
 * Unlike GlovePIE and FreePIE SimIO does not provide any user interface or editor.

## Installation
``` console
$ dotnet -i new simio
```

then for each new project
``` console
$ dotnet new simioconsole
```
or
``` console
$ dotnet new simioblazor
```

Code Example

``` csharp
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
```


[Development Log](DEVLOG.md)


[Changelog](CHANGELOG.md)