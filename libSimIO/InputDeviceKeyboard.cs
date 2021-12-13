/* ----------------------------------------------------------------------- *

    * InputDeviceKeyboard.cs

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

using static th.simio.ElementIdentifier;
using static th.simio.ElementIdentifier.ElementType;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Keyboard
{
  public static readonly HidIdentifier a = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyA, "a");
  public static readonly HidIdentifier b = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyB, "b");
  public static readonly HidIdentifier c = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyC, "c");
  public static readonly HidIdentifier d = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyD, "d");
  public static readonly HidIdentifier e = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyE, "e");
  public static readonly HidIdentifier f = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF, "f");
  public static readonly HidIdentifier g = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyG, "g");
  public static readonly HidIdentifier h = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyH, "h");
  public static readonly HidIdentifier i = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyI, "i");
  public static readonly HidIdentifier j = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyJ, "j");
  public static readonly HidIdentifier k = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyK, "k");
  public static readonly HidIdentifier l = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyL, "l");
  public static readonly HidIdentifier m = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyM, "m");
  public static readonly HidIdentifier n = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyN, "n");
  public static readonly HidIdentifier o = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyO, "o");
  public static readonly HidIdentifier p = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyP, "p");
  public static readonly HidIdentifier q = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyQ, "q");
  public static readonly HidIdentifier r = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyR, "r");
  public static readonly HidIdentifier s = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyS, "s");
  public static readonly HidIdentifier t = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyT, "t");
  public static readonly HidIdentifier u = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyU, "u");
  public static readonly HidIdentifier v = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyV, "v");
  public static readonly HidIdentifier w = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyW, "w");
  public static readonly HidIdentifier x = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyX, "x");
  public static readonly HidIdentifier y = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyY, "y");
  public static readonly HidIdentifier z = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyZ, "z");
  public static readonly HidIdentifier digit1 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key1, "1");
  public static readonly HidIdentifier digit2 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key2, "2");
  public static readonly HidIdentifier digit3 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key3, "3");
  public static readonly HidIdentifier digit4 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key4, "4");
  public static readonly HidIdentifier digit5 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key5, "5");
  public static readonly HidIdentifier digit6 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key6, "6");
  public static readonly HidIdentifier digit7 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key7, "7");
  public static readonly HidIdentifier digit8 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key8, "8");
  public static readonly HidIdentifier digit9 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key9, "9");
  public static readonly HidIdentifier digit0 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.Key0, "0");
  public static readonly HidIdentifier enter = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyEnter, "enter");
  public static readonly HidIdentifier escape = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyEscape, "escape");
  public static readonly HidIdentifier backspace = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyBackspace, "backspace");
  public static readonly HidIdentifier tab = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyTab, "tab");
  public static readonly HidIdentifier space = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeySpace, "space");
  public static readonly HidIdentifier minus = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyMinus, "minus");
  public static readonly HidIdentifier equals = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyEquals, "equals");
  public static readonly HidIdentifier leftbracket = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeftBracket, "leftbracket");
  public static readonly HidIdentifier rightbracket = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRightBracket, "rightbracket");
  public static readonly HidIdentifier backslash = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyBackslash, "backslash");
  public static readonly HidIdentifier semicolon = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeySemicolon, "semicolon");
  public static readonly HidIdentifier quote = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyQuote, "quote");
  public static readonly HidIdentifier grave = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyGrave, "grave");
  public static readonly HidIdentifier comma = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyComma, "comma");
  public static readonly HidIdentifier period = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyPeriod, "period");
  public static readonly HidIdentifier slash = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeySlash, "slash");
  public static readonly HidIdentifier capslock = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyCapslock, "capslock");
  public static readonly HidIdentifier f1 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF1, "f1");
  public static readonly HidIdentifier f2 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF2, "f2");
  public static readonly HidIdentifier f3 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF3, "f3");
  public static readonly HidIdentifier f4 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF4, "f4");
  public static readonly HidIdentifier f5 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF5, "f5");
  public static readonly HidIdentifier f6 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF6, "f6");
  public static readonly HidIdentifier f7 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF7, "f7");
  public static readonly HidIdentifier f8 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF8, "f8");
  public static readonly HidIdentifier f9 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF9, "f9");
  public static readonly HidIdentifier f10 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF10, "f10");
  public static readonly HidIdentifier f11 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF11, "f11");
  public static readonly HidIdentifier f12 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF12, "f12");
  public static readonly HidIdentifier printscreen = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyPrintScreen, "printscreen");
  public static readonly HidIdentifier scrolllock = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyScrollLock, "scrolllock");
  public static readonly HidIdentifier pause = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyPause, "pause");
  public static readonly HidIdentifier insert = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyInsert, "insert");
  public static readonly HidIdentifier home = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyHome, "home");
  public static readonly HidIdentifier pageup = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyPageup, "pageup");
  public static readonly HidIdentifier deleteforward = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyDeleteForward, "deleteforward");
  public static readonly HidIdentifier end = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyEnd, "end");
  public static readonly HidIdentifier pagedown = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyPageDown, "pagedown");
  public static readonly HidIdentifier right = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRight, "right");
  public static readonly HidIdentifier left = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeft, "left");
  public static readonly HidIdentifier down = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyDown, "down");
  public static readonly HidIdentifier up = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyUp, "up");
  public static readonly HidIdentifier kpnumlock = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpNumLock, "kpnumlock");
  public static readonly HidIdentifier kpdivide = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpDivide, "kpdivide");
  public static readonly HidIdentifier kpmultiply = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpMultiply, "kpmultiply");
  public static readonly HidIdentifier kpsubtract = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpSubtract, "kpsubtract");
  public static readonly HidIdentifier kpadd = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpAdd, "kpadd");
  public static readonly HidIdentifier kpenter = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpEnter, "kpenter");
  public static readonly HidIdentifier kp1 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp1, "kp1");
  public static readonly HidIdentifier kp2 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp2, "kp2");
  public static readonly HidIdentifier kp3 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp3, "kp3");
  public static readonly HidIdentifier kp4 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp4, "kp4");
  public static readonly HidIdentifier kp5 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp5, "kp5");
  public static readonly HidIdentifier kp6 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp6, "kp6");
  public static readonly HidIdentifier kp7 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp7, "kp7");
  public static readonly HidIdentifier kp8 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp8, "kp8");
  public static readonly HidIdentifier kp9 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp9, "kp9");
  public static readonly HidIdentifier kp0 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKp0, "kp0");
  public static readonly HidIdentifier kppoint = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpPoint, "kppoint");
  public static readonly HidIdentifier nonusbackslash = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyNonUsBackslash, "nonusbackslash");
  public static readonly HidIdentifier kpequals = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpEquals, "kpequals");
  public static readonly HidIdentifier f13 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF13, "f13");
  public static readonly HidIdentifier f14 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF14, "f14");
  public static readonly HidIdentifier f15 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF15, "f15");
  public static readonly HidIdentifier f16 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF16, "f16");
  public static readonly HidIdentifier f17 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF17, "f17");
  public static readonly HidIdentifier f18 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF18, "f18");
  public static readonly HidIdentifier f19 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF19, "f19");
  public static readonly HidIdentifier f20 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF20, "f20");
  public static readonly HidIdentifier f21 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF21, "f21");
  public static readonly HidIdentifier f22 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF22, "f22");
  public static readonly HidIdentifier f23 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF23, "f23");
  public static readonly HidIdentifier f24 = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyF24, "f24");
  public static readonly HidIdentifier help = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyHelp, "help");
  public static readonly HidIdentifier menu = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyMenu, "menu");
  public static readonly HidIdentifier mute = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyMute, "mute");
  public static readonly HidIdentifier sysreq = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeySysreq, "sysreq");
  public static readonly HidIdentifier @return = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyReturn, "return");
  public static readonly HidIdentifier kpclear = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpClear, "kpclear");
  public static readonly HidIdentifier kpdecimal = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyKpDecimal, "kpdecimal");
  public static readonly HidIdentifier leftcontrol = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeftControl, "leftcontrol");
  public static readonly HidIdentifier leftshift = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeftShift, "leftshift");
  public static readonly HidIdentifier leftalt = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeftAlt, "leftalt");
  public static readonly HidIdentifier leftgui = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyLeftGui, "leftgui");
  public static readonly HidIdentifier rightcontrol = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRightControl, "rightcontrol");
  public static readonly HidIdentifier rightshift = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRightShift, "rightshift");
  public static readonly HidIdentifier rightalt = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRightAlt, "rightalt");
  public static readonly HidIdentifier rightgui = new HidIdentifier(typeof(ElementIdentifier.ElementType.Key), HidUsage.UsagePage.Keyboard, HidUsage.Usage.KeyRightGui, "rightgui");

  public static readonly HidIdentifier[] keys = new HidIdentifier[] {
    a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, digit1, digit2, digit3, digit4, digit5, digit6, digit7, digit8, digit9, digit0,
    enter, escape, backspace, tab, space, minus, equals, leftbracket, rightbracket, backslash, semicolon, quote, grave, comma, period, slash, capslock,
    f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, printscreen, scrolllock, pause, insert, home, pageup, deleteforward, end, pagedown, right, left, down, up,
    kpnumlock, kpdivide, kpmultiply, kpsubtract, kpadd, kpenter, kp1, kp2, kp3, kp4, kp5, kp6, kp7, kp8, kp9, kp0, kppoint, nonusbackslash, kpequals, f13, f14, f15,
    f16, f17, f18, f19, f20, f21, f22, f23, f24, help, menu, mute, sysreq, @return, kpclear, kpdecimal, leftcontrol, leftshift, leftalt, leftgui, rightcontrol, rightshift, rightalt, rightgui
  };
}

} // End of namespace th.simio
