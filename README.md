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
using System.Linq;
using th.simio;

public class OutputTest
{
  static void Main()
  {
    bool running = true;

    InputDevice joystick = SimIO.inputDevices.First(d => d.deviceType == typeof(InputDevice.DeviceType.Joystick));
    // Alternative for above line
    // InputDevice joystick = SimIO.inputDevices.First(d => d is RawInputHID && (d as RawInputHID).productString == "Saitek X52 Flight Control System");
    OutputDevice keyboard = SimIO.outputDevices.First(d => d.deviceType == typeof(InputDevice.DeviceType.Keyboard));

    InputDevice.Element joystickXAxis = joystick.elements.First(e => e.id == new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.X));
    InputDevice.Element joystickYAxis = joystick.elements.First(e => e.id == new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Y));
    InputDevice.Element joystickThrottleAxis = joystick.elements.First(e => e.id == new HidIdentifier(typeof(ElementIdentifier.ElementType.AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Z));

    OutputDevice.Element wKey = keyboard.elements.First(e => e.id == Keyboard.w);
    OutputDevice.Element sKey = keyboard.elements.First(e => e.id == Keyboard.s);
    OutputDevice.Element aKey = keyboard.elements.First(e => e.id == Keyboard.a);
    OutputDevice.Element dKey = keyboard.elements.First(e => e.id == Keyboard.d);
    OutputDevice.Element shiftKey = keyboard.elements.First(e => e.id == Keyboard.leftshift);

    SimIO.onInput += (device, element) => {
      if (device.deviceType == typeof(InputDevice.DeviceType.Keyboard) && element.id == Keyboard.escape && element.motion > 0)
        running = false;
    };

    joystick.onInput += (device, element) => {
      if (element.id.type == typeof(ElementIdentifier.ElementType.Button)) {
        Console.WriteLine("Button " + element.id.name + " " + (element.motion > 0 ? "pressed" : "released"));
      }
    };

    float xAxisMidPoint = (joystickXAxis.maximumValue + joystickXAxis.minimumValue) * 0.5f;

    // Halfway to left
    float leftThreshold = xAxisMidPoint - ((xAxisMidPoint - joystickXAxis.minimumValue) * 0.5f);
    // Halfway to right
    float rightThreshold = xAxisMidPoint + ((joystickXAxis.maximumValue - xAxisMidPoint) * 0.5f);


    joystickXAxis.onInput += (d, e) => {
      aKey.value = e.position < leftThreshold ? 1 : 0;
      dKey.value = e.position > rightThreshold ? 1 : 0;
    };

    // Halfway to left
    float forwardThreshold = xAxisMidPoint - ((xAxisMidPoint - joystickXAxis.minimumValue) * 0.5f);
    // Halfway to right
    float backwardThreshold = xAxisMidPoint + ((joystickXAxis.maximumValue - xAxisMidPoint) * 0.5f);

    joystickYAxis.onInput += (d, e) => {
      wKey.value = e.position < forwardThreshold ? 1 : 0;
      sKey.value = e.position >  backwardThreshold ? 1 : 0;
    };

    while(running) {
      SimIO.update();

      if (joystickThrottleAxis.value < 0.5f) {
        Console.WriteLine("SPEED AND POWER!");
        shiftKey.value = 1;
      }
      else
        shiftKey.value = 0;

      Thread.Sleep(16);
    }

    Console.WriteLine("Ok");
  }
}
```