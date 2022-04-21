/* ----------------------------------------------------------------------- *

    * RawInputKeyboard.cs

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
public class RawInputKeyboard : RawInputDevice
{
  // Key is scandode, value is hid usage
  static internal readonly Dictionary<ushort, Int32> scancodeTranslationTable = new Dictionary<ushort, Int32>() {
    {0x001e, 0x04},  {0x0030, 0x05},  {0x002e, 0x06},  {0x0020, 0x07},  {0x0012, 0x08},  {0x0021, 0x09},  {0x0022, 0x0a},  {0x0023, 0x0b},
    {0x0017, 0x0c},  {0x0024, 0x0d},  {0x0025, 0x0e},  {0x0026, 0x0f},  {0x0032, 0x10},  {0x0031, 0x11},  {0x0018, 0x12},  {0x0019, 0x13},
    {0x0010, 0x14},  {0x0013, 0x15},  {0x001f, 0x16},  {0x0014, 0x17},  {0x0016, 0x18},  {0x002f, 0x19},  {0x0011, 0x1a},  {0x002d, 0x1b},
    {0x0015, 0x1c},  {0x002c, 0x1d},  {0x0002, 0x1e},  {0x0003, 0x1f},  {0x0004, 0x20},  {0x0005, 0x21},  {0x0006, 0x22},  {0x0007, 0x23},
    {0x0008, 0x24},  {0x0009, 0x25},  {0x000a, 0x26},  {0x000b, 0x27},  {0x001c, 0x28},  {0x0001, 0x29},  {0x000e, 0x2a},  {0x000f, 0x2b},
    {0x0039, 0x2c},  {0x000c, 0x2d},  {0x000d, 0x2e},  {0x001a, 0x2f},  {0x001b, 0x30},  {0x002b, 0x31},  {0x0027, 0x33},  {0x0028, 0x34},
    {0x0029, 0x35},  {0x0033, 0x36},  {0x0034, 0x37},  {0x0035, 0x38},  {0x003a, 0x39},  {0x003b, 0x3a},  {0x003c, 0x3b},  {0x003d, 0x3c},
    {0x003e, 0x3d},  {0x003f, 0x3e},  {0x0040, 0x3f},  {0x0041, 0x40},  {0x0042, 0x41},  {0x0043, 0x42},  {0x0044, 0x43},  {0x0057, 0x44},
    {0x0058, 0x45},  {0xe037, 0x46},  {0x0046, 0x47},  {0xe052, 0x49},  {0xe047, 0x4a},  {0xe049, 0x4b},  {0xe053, 0x4c},  {0xe04f, 0x4d},
    {0xe051, 0x4e},  {0xe04d, 0x4f},  {0xe04b, 0x50},  {0xe050, 0x51},  {0xe048, 0x52},  {0x0045, 0x53},  {0xe035, 0x54},  {0x0037, 0x55},
    {0x004a, 0x56},  {0x004e, 0x57},  {0xe01c, 0x58},  {0x004f, 0x59},  {0x0050, 0x5a},  {0x0051, 0x5b},  {0x004b, 0x5c},  {0x004c, 0x5d},
    {0x004d, 0x5e},  {0x0047, 0x5f},  {0x0048, 0x60},  {0x0049, 0x61},  {0x0052, 0x62},  {0x0053, 0x63},  {0x0056, 0x64},  {0xe05e, 0x66},
    {0x0059, 0x67},  {0x0064, 0x68},  {0x0065, 0x69},  {0x0066, 0x6a},  {0x0067, 0x6b},  {0x0068, 0x6c},  {0x0069, 0x6d},  {0x006a, 0x6e},
    {0x006b, 0x6f},  {0x006c, 0x70},  {0x006d, 0x71},  {0x006e, 0x72},  {0x0076, 0x73},  {0x007e, 0x85},  {0x0073, 0x87},  {0x0070, 0x88},
    {0x007d, 0x89},  {0x0079, 0x8a},  {0x007b, 0x8b},  {0x005c, 0x8c},  {0x00f2, 0x90},  {0x00f1, 0x91},  {0x0078, 0x92},  {0x0077, 0x93},
    {0x001d, 0xe0},  {0x002a, 0xe1},  {0x0038, 0xe2},  {0xe05b, 0xe3},  {0xe01d, 0xe4},  {0x0036, 0xe5},  {0xe038, 0xe6},  {0xe05d, 0xe7}
  };

  Dictionary<int, RawInputDeviceElement> elementMap = new Dictionary<int, RawInputDeviceElement>();

  // -------------------------------------------------------------------------
  internal RawInputKeyboard(IntPtr deviceHandle, string devicePath, RID_DEVICE_INFO deviceInfo) : base(deviceHandle, devicePath, deviceInfo)
  {
    deviceType = typeof(InputDevice.DeviceType.Keyboard);
    List<RawInputDeviceElement> elements = new List<RawInputDeviceElement>() {
      new RawInputDeviceElement(this, Keyboard.a),
      new RawInputDeviceElement(this, Keyboard.b),
      new RawInputDeviceElement(this, Keyboard.c),
      new RawInputDeviceElement(this, Keyboard.d),
      new RawInputDeviceElement(this, Keyboard.e),
      new RawInputDeviceElement(this, Keyboard.f),
      new RawInputDeviceElement(this, Keyboard.g),
      new RawInputDeviceElement(this, Keyboard.h),
      new RawInputDeviceElement(this, Keyboard.i),
      new RawInputDeviceElement(this, Keyboard.j),
      new RawInputDeviceElement(this, Keyboard.k),
      new RawInputDeviceElement(this, Keyboard.l),
      new RawInputDeviceElement(this, Keyboard.m),
      new RawInputDeviceElement(this, Keyboard.n),
      new RawInputDeviceElement(this, Keyboard.o),
      new RawInputDeviceElement(this, Keyboard.p),
      new RawInputDeviceElement(this, Keyboard.q),
      new RawInputDeviceElement(this, Keyboard.r),
      new RawInputDeviceElement(this, Keyboard.s),
      new RawInputDeviceElement(this, Keyboard.t),
      new RawInputDeviceElement(this, Keyboard.u),
      new RawInputDeviceElement(this, Keyboard.v),
      new RawInputDeviceElement(this, Keyboard.w),
      new RawInputDeviceElement(this, Keyboard.x),
      new RawInputDeviceElement(this, Keyboard.y),
      new RawInputDeviceElement(this, Keyboard.z),
      new RawInputDeviceElement(this, Keyboard.digit1),
      new RawInputDeviceElement(this, Keyboard.digit2),
      new RawInputDeviceElement(this, Keyboard.digit3),
      new RawInputDeviceElement(this, Keyboard.digit4),
      new RawInputDeviceElement(this, Keyboard.digit5),
      new RawInputDeviceElement(this, Keyboard.digit6),
      new RawInputDeviceElement(this, Keyboard.digit7),
      new RawInputDeviceElement(this, Keyboard.digit8),
      new RawInputDeviceElement(this, Keyboard.digit9),
      new RawInputDeviceElement(this, Keyboard.digit0),
      new RawInputDeviceElement(this, Keyboard.enter),
      new RawInputDeviceElement(this, Keyboard.escape),
      new RawInputDeviceElement(this, Keyboard.backspace),
      new RawInputDeviceElement(this, Keyboard.tab),
      new RawInputDeviceElement(this, Keyboard.space),
      new RawInputDeviceElement(this, Keyboard.minus),
      new RawInputDeviceElement(this, Keyboard.equals),
      new RawInputDeviceElement(this, Keyboard.leftbracket),
      new RawInputDeviceElement(this, Keyboard.rightbracket),
      new RawInputDeviceElement(this, Keyboard.backslash),
      new RawInputDeviceElement(this, Keyboard.semicolon),
      new RawInputDeviceElement(this, Keyboard.quote),
      new RawInputDeviceElement(this, Keyboard.grave),
      new RawInputDeviceElement(this, Keyboard.comma),
      new RawInputDeviceElement(this, Keyboard.period),
      new RawInputDeviceElement(this, Keyboard.slash),
      new RawInputDeviceElement(this, Keyboard.capslock),
      new RawInputDeviceElement(this, Keyboard.f1),
      new RawInputDeviceElement(this, Keyboard.f2),
      new RawInputDeviceElement(this, Keyboard.f3),
      new RawInputDeviceElement(this, Keyboard.f4),
      new RawInputDeviceElement(this, Keyboard.f5),
      new RawInputDeviceElement(this, Keyboard.f6),
      new RawInputDeviceElement(this, Keyboard.f7),
      new RawInputDeviceElement(this, Keyboard.f8),
      new RawInputDeviceElement(this, Keyboard.f9),
      new RawInputDeviceElement(this, Keyboard.f10),
      new RawInputDeviceElement(this, Keyboard.f11),
      new RawInputDeviceElement(this, Keyboard.f12),
      new RawInputDeviceElement(this, Keyboard.printscreen),
      new RawInputDeviceElement(this, Keyboard.scrolllock),
      new RawInputDeviceElement(this, Keyboard.pause),
      new RawInputDeviceElement(this, Keyboard.insert),
      new RawInputDeviceElement(this, Keyboard.home),
      new RawInputDeviceElement(this, Keyboard.pageup),
      new RawInputDeviceElement(this, Keyboard.deleteforward),
      new RawInputDeviceElement(this, Keyboard.end),
      new RawInputDeviceElement(this, Keyboard.pagedown),
      new RawInputDeviceElement(this, Keyboard.right),
      new RawInputDeviceElement(this, Keyboard.left),
      new RawInputDeviceElement(this, Keyboard.down),
      new RawInputDeviceElement(this, Keyboard.up),
      new RawInputDeviceElement(this, Keyboard.kpnumlock),
      new RawInputDeviceElement(this, Keyboard.kpdivide),
      new RawInputDeviceElement(this, Keyboard.kpmultiply),
      new RawInputDeviceElement(this, Keyboard.kpsubtract),
      new RawInputDeviceElement(this, Keyboard.kpadd),
      new RawInputDeviceElement(this, Keyboard.kpenter),
      new RawInputDeviceElement(this, Keyboard.kp1),
      new RawInputDeviceElement(this, Keyboard.kp2),
      new RawInputDeviceElement(this, Keyboard.kp3),
      new RawInputDeviceElement(this, Keyboard.kp4),
      new RawInputDeviceElement(this, Keyboard.kp5),
      new RawInputDeviceElement(this, Keyboard.kp6),
      new RawInputDeviceElement(this, Keyboard.kp7),
      new RawInputDeviceElement(this, Keyboard.kp8),
      new RawInputDeviceElement(this, Keyboard.kp9),
      new RawInputDeviceElement(this, Keyboard.kp0),
      new RawInputDeviceElement(this, Keyboard.kppoint),
      new RawInputDeviceElement(this, Keyboard.nonusbackslash),
      new RawInputDeviceElement(this, Keyboard.kpequals),
      new RawInputDeviceElement(this, Keyboard.f13),
      new RawInputDeviceElement(this, Keyboard.f14),
      new RawInputDeviceElement(this, Keyboard.f15),
      new RawInputDeviceElement(this, Keyboard.f16),
      new RawInputDeviceElement(this, Keyboard.f17),
      new RawInputDeviceElement(this, Keyboard.f18),
      new RawInputDeviceElement(this, Keyboard.f19),
      new RawInputDeviceElement(this, Keyboard.f20),
      new RawInputDeviceElement(this, Keyboard.f21),
      new RawInputDeviceElement(this, Keyboard.f22),
      new RawInputDeviceElement(this, Keyboard.f23),
      new RawInputDeviceElement(this, Keyboard.f24),
      new RawInputDeviceElement(this, Keyboard.help),
      new RawInputDeviceElement(this, Keyboard.menu),
      new RawInputDeviceElement(this, Keyboard.mute),
      new RawInputDeviceElement(this, Keyboard.sysreq),
      new RawInputDeviceElement(this, Keyboard.@return),
      new RawInputDeviceElement(this, Keyboard.kpclear),
      new RawInputDeviceElement(this, Keyboard.kpdecimal),
      new RawInputDeviceElement(this, Keyboard.leftcontrol),
      new RawInputDeviceElement(this, Keyboard.leftshift),
      new RawInputDeviceElement(this, Keyboard.leftalt),
      new RawInputDeviceElement(this, Keyboard.leftgui),
      new RawInputDeviceElement(this, Keyboard.rightcontrol),
      new RawInputDeviceElement(this, Keyboard.rightshift),
      new RawInputDeviceElement(this, Keyboard.rightalt),
      new RawInputDeviceElement(this, Keyboard.rightgui)
    };
    foreach(var elem in elements) {
      elem.onInput += (d, e) => notifyInput(d, e);
      elementMap.Add((int) ((HidIdentifier) elem.identifier).usage, elem);
    }
    _elements = elements.ToArray();
  }

  // -------------------------------------------------------------------------
  internal unsafe override void update(RAWINPUT *data)
  {
    RAWKEYBOARD k = data->keyboard;
    Int32 usage;
    if (scancodeTranslationTable.TryGetValue((ushort) (k.MakeCode | ((k.Flags & RI_KEY_E0) != 0 ? 0xE000 : 0) | ((k.Flags & RI_KEY_E1) != 0 ? 0xE100 : 0)), out usage)) {
      RawInputDeviceElement element;
      if (elementMap.TryGetValue(usage, out element)) {
        element.setAbsoluteData((k.Flags & RI_KEY_BREAK) != 0 ? 0.0f : 1.0f);
      }
    }
  }
}

} // End of namespace th.simio
