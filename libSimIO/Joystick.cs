/* ----------------------------------------------------------------------- *

    * Joystick.cs

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

namespace th.SimIO {

using AbsoluteAxis = ElementIdentifier.ElementType.AbsoluteAxis;
using Button = ElementIdentifier.ElementType.Button;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Joystick
{
  public readonly static ElementIdentifier x = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.X, "x axis");
  public readonly static ElementIdentifier y = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Y, "y axis");
  public readonly static ElementIdentifier z = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Z, "z axis");
  public readonly static ElementIdentifier xRotation = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Rx, "x rotation");
  public readonly static ElementIdentifier yRotation = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Ry, "y rotation");
  public readonly static ElementIdentifier zRotation = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Rz, "z rotation");
  public readonly static ElementIdentifier slider = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Slider, "slider");
  public readonly static ElementIdentifier dial = new HidIdentifier(typeof(AbsoluteAxis), HidUsage.UsagePage.GenericDesktop, HidUsage.Usage.Dial, "dial");

  public readonly static ElementIdentifier button1 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 1, "button 1");
  public readonly static ElementIdentifier button2 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 2, "button 2");
  public readonly static ElementIdentifier button3 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 3, "button 3");
  public readonly static ElementIdentifier button4 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 4, "button 4");
  public readonly static ElementIdentifier button5 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 5, "button 5");
  public readonly static ElementIdentifier button6 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 6, "button 6");
  public readonly static ElementIdentifier button7 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 7, "button 7");
  public readonly static ElementIdentifier button8 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 8, "button 8");
  public readonly static ElementIdentifier button9 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 9, "button 9");
  public readonly static ElementIdentifier button10 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 10, "button 10");
  public readonly static ElementIdentifier button11 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 11, "button 11");
  public readonly static ElementIdentifier button12 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 12, "button 12");
  public readonly static ElementIdentifier button13 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 13, "button 13");
  public readonly static ElementIdentifier button14 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 14, "button 14");
  public readonly static ElementIdentifier button15 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 15, "button 15");
  public readonly static ElementIdentifier button16 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 16, "button 16");
  public readonly static ElementIdentifier button17 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 17, "button 17");
  public readonly static ElementIdentifier button18 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 18, "button 18");
  public readonly static ElementIdentifier button19 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 19, "button 19");
  public readonly static ElementIdentifier button20 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 20, "button 20");
  public readonly static ElementIdentifier button21 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 21, "button 21");
  public readonly static ElementIdentifier button22 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 22, "button 22");
  public readonly static ElementIdentifier button23 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 23, "button 23");
  public readonly static ElementIdentifier button24 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 24, "button 24");
  public readonly static ElementIdentifier button25 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 25, "button 25");
  public readonly static ElementIdentifier button26 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 26, "button 26");
  public readonly static ElementIdentifier button27 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 27, "button 27");
  public readonly static ElementIdentifier button28 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 28, "button 28");
  public readonly static ElementIdentifier button29 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 29, "button 29");
  public readonly static ElementIdentifier button30 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 30, "button 30");
  public readonly static ElementIdentifier button31 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 31, "button 31");
  public readonly static ElementIdentifier button32 = new HidIdentifier(typeof(Button), HidUsage.UsagePage.Button, (HidUsage.Usage) 32, "button 32");

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class InputDeviceWrapper : InputDevice.Wrapper
  {
    public InputDevice.Element x;
    public InputDevice.Element y;
    public InputDevice.Element z;
    public InputDevice.Element xRotation;
    public InputDevice.Element yRotation;
    public InputDevice.Element zRotation;
    public InputDevice.Element slider;
    public InputDevice.Element dial;
    public InputDevice.Element button1;
    public InputDevice.Element button2;
    public InputDevice.Element button3;
    public InputDevice.Element button4;
    public InputDevice.Element button5;
    public InputDevice.Element button6;
    public InputDevice.Element button7;
    public InputDevice.Element button8;
    public InputDevice.Element button9;
    public InputDevice.Element button10;
    public InputDevice.Element button11;
    public InputDevice.Element button12;
    public InputDevice.Element button13;
    public InputDevice.Element button14;
    public InputDevice.Element button15;
    public InputDevice.Element button16;
    public InputDevice.Element button17;
    public InputDevice.Element button18;
    public InputDevice.Element button19;
    public InputDevice.Element button20;
    public InputDevice.Element button21;
    public InputDevice.Element button22;
    public InputDevice.Element button23;
    public InputDevice.Element button24;
    public InputDevice.Element button25;
    public InputDevice.Element button26;
    public InputDevice.Element button27;
    public InputDevice.Element button28;
    public InputDevice.Element button29;
    public InputDevice.Element button30;
    public InputDevice.Element button31;
    public InputDevice.Element button32;

    // -----------------------------------------------------------------------
    public InputDeviceWrapper() : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Joystick>()))
    {
    }

    // -----------------------------------------------------------------------
    public InputDeviceWrapper(Func<InputDevice, bool> predicate) : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Joystick>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    public InputDeviceWrapper(InputDevice device) : base(device)
    {
      x = device[Joystick.x];
      y = device[Joystick.y];
      z = device[Joystick.z];
      xRotation = device[Joystick.xRotation];
      yRotation = device[Joystick.yRotation];
      zRotation = device[Joystick.zRotation];
      slider = device[Joystick.slider];
      dial = device[Joystick.dial];
      button1 = device[Joystick.button1];
      button2 = device[Joystick.button2];
      button3 = device[Joystick.button3];
      button4 = device[Joystick.button4];
      button5 = device[Joystick.button5];
      button6 = device[Joystick.button6];
      button7 = device[Joystick.button7];
      button8 = device[Joystick.button8];
      button9 = device[Joystick.button9];
      button10 = device[Joystick.button10];
      button11 = device[Joystick.button11];
      button12 = device[Joystick.button12];
      button13 = device[Joystick.button13];
      button14 = device[Joystick.button14];
      button15 = device[Joystick.button15];
      button16 = device[Joystick.button16];
      button17 = device[Joystick.button17];
      button18 = device[Joystick.button18];
      button19 = device[Joystick.button19];
      button20 = device[Joystick.button20];
      button21 = device[Joystick.button21];
      button22 = device[Joystick.button22];
      button23 = device[Joystick.button23];
      button24 = device[Joystick.button24];
      button25 = device[Joystick.button25];
      button26 = device[Joystick.button26];
      button27 = device[Joystick.button27];
      button28 = device[Joystick.button28];
      button29 = device[Joystick.button29];
      button30 = device[Joystick.button30];
      button31 = device[Joystick.button31];
      button32 = device[Joystick.button32];
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class OutputDeviceWrapper : OutputDevice.Wrapper
  {
    public OutputDevice.Element x;
    public OutputDevice.Element y;
    public OutputDevice.Element z;
    public OutputDevice.Element xRotation;
    public OutputDevice.Element yRotation;
    public OutputDevice.Element zRotation;
    public OutputDevice.Element slider;
    public OutputDevice.Element dial;
    public OutputDevice.Element button1;
    public OutputDevice.Element button2;
    public OutputDevice.Element button3;
    public OutputDevice.Element button4;
    public OutputDevice.Element button5;
    public OutputDevice.Element button6;
    public OutputDevice.Element button7;
    public OutputDevice.Element button8;
    public OutputDevice.Element button9;
    public OutputDevice.Element button10;
    public OutputDevice.Element button11;
    public OutputDevice.Element button12;
    public OutputDevice.Element button13;
    public OutputDevice.Element button14;
    public OutputDevice.Element button15;
    public OutputDevice.Element button16;
    public OutputDevice.Element button17;
    public OutputDevice.Element button18;
    public OutputDevice.Element button19;
    public OutputDevice.Element button20;
    public OutputDevice.Element button21;
    public OutputDevice.Element button22;
    public OutputDevice.Element button23;
    public OutputDevice.Element button24;
    public OutputDevice.Element button25;
    public OutputDevice.Element button26;
    public OutputDevice.Element button27;
    public OutputDevice.Element button28;
    public OutputDevice.Element button29;
    public OutputDevice.Element button30;
    public OutputDevice.Element button31;
    public OutputDevice.Element button32;

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper() : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Joystick>()))
    {
    }

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper(Func<OutputDevice, bool> predicate) : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Joystick>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper(OutputDevice device) : base(device)
    {
      x = device[Joystick.x];
      y = device[Joystick.y];
      z = device[Joystick.z];
      xRotation = device[Joystick.xRotation];
      yRotation = device[Joystick.yRotation];
      zRotation = device[Joystick.zRotation];
      slider = device[Joystick.slider];
      dial = device[Joystick.dial];
      button1 = device[Joystick.button1];
      button2 = device[Joystick.button2];
      button3 = device[Joystick.button3];
      button4 = device[Joystick.button4];
      button5 = device[Joystick.button5];
      button6 = device[Joystick.button6];
      button7 = device[Joystick.button7];
      button8 = device[Joystick.button8];
      button9 = device[Joystick.button9];
      button10 = device[Joystick.button10];
      button11 = device[Joystick.button11];
      button12 = device[Joystick.button12];
      button13 = device[Joystick.button13];
      button14 = device[Joystick.button14];
      button15 = device[Joystick.button15];
      button16 = device[Joystick.button16];
      button17 = device[Joystick.button17];
      button18 = device[Joystick.button18];
      button19 = device[Joystick.button19];
      button20 = device[Joystick.button20];
      button21 = device[Joystick.button21];
      button22 = device[Joystick.button22];
      button23 = device[Joystick.button23];
      button24 = device[Joystick.button24];
      button25 = device[Joystick.button25];
      button26 = device[Joystick.button26];
      button27 = device[Joystick.button27];
      button28 = device[Joystick.button28];
      button29 = device[Joystick.button29];
      button30 = device[Joystick.button30];
      button31 = device[Joystick.button31];
      button32 = device[Joystick.button32];
    }
  }

}

} // End of namespace th.simio
