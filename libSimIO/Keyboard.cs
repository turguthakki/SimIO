/* ----------------------------------------------------------------------- *

    * Keyboard.cs

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

using static th.SimIO.ElementIdentifier;
using static th.SimIO.ElementIdentifier.ElementType;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Element identifiers for keyboards.
/// </summary>
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

  /// <summary>
  /// Convenience variable for all keyboard identifiers
  /// </summary>
  public static readonly HidIdentifier[] keys = new HidIdentifier[] {
    a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, digit1, digit2, digit3, digit4, digit5, digit6, digit7, digit8, digit9, digit0,
    enter, escape, backspace, tab, space, minus, equals, leftbracket, rightbracket, backslash, semicolon, quote, grave, comma, period, slash, capslock,
    f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, printscreen, scrolllock, pause, insert, home, pageup, deleteforward, end, pagedown, right, left, down, up,
    kpnumlock, kpdivide, kpmultiply, kpsubtract, kpadd, kpenter, kp1, kp2, kp3, kp4, kp5, kp6, kp7, kp8, kp9, kp0, kppoint, nonusbackslash, kpequals, f13, f14, f15,
    f16, f17, f18, f19, f20, f21, f22, f23, f24, help, menu, mute, sysreq, @return, kpclear, kpdecimal, leftcontrol, leftshift, leftalt, leftgui, rightcontrol, rightshift, rightalt, rightgui
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class InputDeviceWrapper : InputDevice.Wrapper
  {
    public InputDevice.Element a;
    public InputDevice.Element b;
    public InputDevice.Element c;
    public InputDevice.Element d;
    public InputDevice.Element e;
    public InputDevice.Element f;
    public InputDevice.Element g;
    public InputDevice.Element h;
    public InputDevice.Element i;
    public InputDevice.Element j;
    public InputDevice.Element k;
    public InputDevice.Element l;
    public InputDevice.Element m;
    public InputDevice.Element n;
    public InputDevice.Element o;
    public InputDevice.Element p;
    public InputDevice.Element q;
    public InputDevice.Element r;
    public InputDevice.Element s;
    public InputDevice.Element t;
    public InputDevice.Element u;
    public InputDevice.Element v;
    public InputDevice.Element w;
    public InputDevice.Element x;
    public InputDevice.Element y;
    public InputDevice.Element z;
    public InputDevice.Element digit1;
    public InputDevice.Element digit2;
    public InputDevice.Element digit3;
    public InputDevice.Element digit4;
    public InputDevice.Element digit5;
    public InputDevice.Element digit6;
    public InputDevice.Element digit7;
    public InputDevice.Element digit8;
    public InputDevice.Element digit9;
    public InputDevice.Element digit0;
    public InputDevice.Element enter;
    public InputDevice.Element escape;
    public InputDevice.Element backspace;
    public InputDevice.Element tab;
    public InputDevice.Element space;
    public InputDevice.Element minus;
    public InputDevice.Element equals;
    public InputDevice.Element leftbracket;
    public InputDevice.Element rightbracket;
    public InputDevice.Element backslash;
    public InputDevice.Element semicolon;
    public InputDevice.Element quote;
    public InputDevice.Element grave;
    public InputDevice.Element comma;
    public InputDevice.Element period;
    public InputDevice.Element slash;
    public InputDevice.Element capslock;
    public InputDevice.Element f1;
    public InputDevice.Element f2;
    public InputDevice.Element f3;
    public InputDevice.Element f4;
    public InputDevice.Element f5;
    public InputDevice.Element f6;
    public InputDevice.Element f7;
    public InputDevice.Element f8;
    public InputDevice.Element f9;
    public InputDevice.Element f10;
    public InputDevice.Element f11;
    public InputDevice.Element f12;
    public InputDevice.Element printscreen;
    public InputDevice.Element scrolllock;
    public InputDevice.Element pause;
    public InputDevice.Element insert;
    public InputDevice.Element home;
    public InputDevice.Element pageup;
    public InputDevice.Element deleteforward;
    public InputDevice.Element end;
    public InputDevice.Element pagedown;
    public InputDevice.Element right;
    public InputDevice.Element left;
    public InputDevice.Element down;
    public InputDevice.Element up;
    public InputDevice.Element kpnumlock;
    public InputDevice.Element kpdivide;
    public InputDevice.Element kpmultiply;
    public InputDevice.Element kpsubtract;
    public InputDevice.Element kpadd;
    public InputDevice.Element kpenter;
    public InputDevice.Element kp1;
    public InputDevice.Element kp2;
    public InputDevice.Element kp3;
    public InputDevice.Element kp4;
    public InputDevice.Element kp5;
    public InputDevice.Element kp6;
    public InputDevice.Element kp7;
    public InputDevice.Element kp8;
    public InputDevice.Element kp9;
    public InputDevice.Element kp0;
    public InputDevice.Element kppoint;
    public InputDevice.Element nonusbackslash;
    public InputDevice.Element kpequals;
    public InputDevice.Element f13;
    public InputDevice.Element f14;
    public InputDevice.Element f15;
    public InputDevice.Element f16;
    public InputDevice.Element f17;
    public InputDevice.Element f18;
    public InputDevice.Element f19;
    public InputDevice.Element f20;
    public InputDevice.Element f21;
    public InputDevice.Element f22;
    public InputDevice.Element f23;
    public InputDevice.Element f24;
    public InputDevice.Element help;
    public InputDevice.Element menu;
    public InputDevice.Element mute;
    public InputDevice.Element sysreq;
    public InputDevice.Element @return;
    public InputDevice.Element kpclear;
    public InputDevice.Element kpdecimal;
    public InputDevice.Element leftcontrol;
    public InputDevice.Element leftshift;
    public InputDevice.Element leftalt;
    public InputDevice.Element leftgui;
    public InputDevice.Element rightcontrol;
    public InputDevice.Element rightshift;
    public InputDevice.Element rightalt;
    public InputDevice.Element rightgui;

    // -----------------------------------------------------------------------
    public InputDeviceWrapper() : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Keyboard>()))
    {
    }

    // -----------------------------------------------------------------------
    public InputDeviceWrapper(Func<InputDevice, bool> predicate) : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Keyboard>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    public InputDeviceWrapper(InputDevice device) : base(device)
    {
      a = device[Keyboard.a];
      b = device[Keyboard.b];
      c = device[Keyboard.c];
      d = device[Keyboard.d];
      e = device[Keyboard.e];
      f = device[Keyboard.f];
      g = device[Keyboard.g];
      h = device[Keyboard.h];
      i = device[Keyboard.i];
      j = device[Keyboard.j];
      k = device[Keyboard.k];
      l = device[Keyboard.l];
      m = device[Keyboard.m];
      n = device[Keyboard.n];
      o = device[Keyboard.o];
      p = device[Keyboard.p];
      q = device[Keyboard.q];
      r = device[Keyboard.r];
      s = device[Keyboard.s];
      t = device[Keyboard.t];
      u = device[Keyboard.u];
      v = device[Keyboard.v];
      w = device[Keyboard.w];
      x = device[Keyboard.x];
      y = device[Keyboard.y];
      z = device[Keyboard.z];
      digit1 = device[Keyboard.digit1];
      digit2 = device[Keyboard.digit2];
      digit3 = device[Keyboard.digit3];
      digit4 = device[Keyboard.digit4];
      digit5 = device[Keyboard.digit5];
      digit6 = device[Keyboard.digit6];
      digit7 = device[Keyboard.digit7];
      digit8 = device[Keyboard.digit8];
      digit9 = device[Keyboard.digit9];
      digit0 = device[Keyboard.digit0];
      enter = device[Keyboard.enter];
      escape = device[Keyboard.escape];
      backspace = device[Keyboard.backspace];
      tab = device[Keyboard.tab];
      space = device[Keyboard.space];
      minus = device[Keyboard.minus];
      equals = device[Keyboard.equals];
      leftbracket = device[Keyboard.leftbracket];
      rightbracket = device[Keyboard.rightbracket];
      backslash = device[Keyboard.backslash];
      semicolon = device[Keyboard.semicolon];
      quote = device[Keyboard.quote];
      grave = device[Keyboard.grave];
      comma = device[Keyboard.comma];
      period = device[Keyboard.period];
      slash = device[Keyboard.slash];
      capslock = device[Keyboard.capslock];
      f1 = device[Keyboard.f1];
      f2 = device[Keyboard.f2];
      f3 = device[Keyboard.f3];
      f4 = device[Keyboard.f4];
      f5 = device[Keyboard.f5];
      f6 = device[Keyboard.f6];
      f7 = device[Keyboard.f7];
      f8 = device[Keyboard.f8];
      f9 = device[Keyboard.f9];
      f10 = device[Keyboard.f10];
      f11 = device[Keyboard.f11];
      f12 = device[Keyboard.f12];
      printscreen = device[Keyboard.printscreen];
      scrolllock = device[Keyboard.scrolllock];
      pause = device[Keyboard.pause];
      insert = device[Keyboard.insert];
      home = device[Keyboard.home];
      pageup = device[Keyboard.pageup];
      deleteforward = device[Keyboard.deleteforward];
      end = device[Keyboard.end];
      pagedown = device[Keyboard.pagedown];
      right = device[Keyboard.right];
      left = device[Keyboard.left];
      down = device[Keyboard.down];
      up = device[Keyboard.up];
      kpnumlock = device[Keyboard.kpnumlock];
      kpdivide = device[Keyboard.kpdivide];
      kpmultiply = device[Keyboard.kpmultiply];
      kpsubtract = device[Keyboard.kpsubtract];
      kpadd = device[Keyboard.kpadd];
      kpenter = device[Keyboard.kpenter];
      kp1 = device[Keyboard.kp1];
      kp2 = device[Keyboard.kp2];
      kp3 = device[Keyboard.kp3];
      kp4 = device[Keyboard.kp4];
      kp5 = device[Keyboard.kp5];
      kp6 = device[Keyboard.kp6];
      kp7 = device[Keyboard.kp7];
      kp8 = device[Keyboard.kp8];
      kp9 = device[Keyboard.kp9];
      kp0 = device[Keyboard.kp0];
      kppoint = device[Keyboard.kppoint];
      nonusbackslash = device[Keyboard.nonusbackslash];
      kpequals = device[Keyboard.kpequals];
      f13 = device[Keyboard.f13];
      f14 = device[Keyboard.f14];
      f15 = device[Keyboard.f15];
      f16 = device[Keyboard.f16];
      f17 = device[Keyboard.f17];
      f18 = device[Keyboard.f18];
      f19 = device[Keyboard.f19];
      f20 = device[Keyboard.f20];
      f21 = device[Keyboard.f21];
      f22 = device[Keyboard.f22];
      f23 = device[Keyboard.f23];
      f24 = device[Keyboard.f24];
      help = device[Keyboard.help];
      menu = device[Keyboard.menu];
      mute = device[Keyboard.mute];
      sysreq = device[Keyboard.sysreq];
      @return = device[Keyboard.@return];
      kpclear = device[Keyboard.kpclear];
      kpdecimal = device[Keyboard.kpdecimal];
      leftcontrol = device[Keyboard.leftcontrol];
      leftshift = device[Keyboard.leftshift];
      leftalt = device[Keyboard.leftalt];
      leftgui = device[Keyboard.leftgui];
      rightcontrol = device[Keyboard.rightcontrol];
      rightshift = device[Keyboard.rightshift];
      rightalt = device[Keyboard.rightalt];
      rightgui = device[Keyboard.rightgui];
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class OutputDeviceWrapper : OutputDevice.Wrapper
  {
    public OutputDevice.Element a;
    public OutputDevice.Element b;
    public OutputDevice.Element c;
    public OutputDevice.Element d;
    public OutputDevice.Element e;
    public OutputDevice.Element f;
    public OutputDevice.Element g;
    public OutputDevice.Element h;
    public OutputDevice.Element i;
    public OutputDevice.Element j;
    public OutputDevice.Element k;
    public OutputDevice.Element l;
    public OutputDevice.Element m;
    public OutputDevice.Element n;
    public OutputDevice.Element o;
    public OutputDevice.Element p;
    public OutputDevice.Element q;
    public OutputDevice.Element r;
    public OutputDevice.Element s;
    public OutputDevice.Element t;
    public OutputDevice.Element u;
    public OutputDevice.Element v;
    public OutputDevice.Element w;
    public OutputDevice.Element x;
    public OutputDevice.Element y;
    public OutputDevice.Element z;
    public OutputDevice.Element digit1;
    public OutputDevice.Element digit2;
    public OutputDevice.Element digit3;
    public OutputDevice.Element digit4;
    public OutputDevice.Element digit5;
    public OutputDevice.Element digit6;
    public OutputDevice.Element digit7;
    public OutputDevice.Element digit8;
    public OutputDevice.Element digit9;
    public OutputDevice.Element digit0;
    public OutputDevice.Element enter;
    public OutputDevice.Element escape;
    public OutputDevice.Element backspace;
    public OutputDevice.Element tab;
    public OutputDevice.Element space;
    public OutputDevice.Element minus;
    public OutputDevice.Element equals;
    public OutputDevice.Element leftbracket;
    public OutputDevice.Element rightbracket;
    public OutputDevice.Element backslash;
    public OutputDevice.Element semicolon;
    public OutputDevice.Element quote;
    public OutputDevice.Element grave;
    public OutputDevice.Element comma;
    public OutputDevice.Element period;
    public OutputDevice.Element slash;
    public OutputDevice.Element capslock;
    public OutputDevice.Element f1;
    public OutputDevice.Element f2;
    public OutputDevice.Element f3;
    public OutputDevice.Element f4;
    public OutputDevice.Element f5;
    public OutputDevice.Element f6;
    public OutputDevice.Element f7;
    public OutputDevice.Element f8;
    public OutputDevice.Element f9;
    public OutputDevice.Element f10;
    public OutputDevice.Element f11;
    public OutputDevice.Element f12;
    public OutputDevice.Element printscreen;
    public OutputDevice.Element scrolllock;
    public OutputDevice.Element pause;
    public OutputDevice.Element insert;
    public OutputDevice.Element home;
    public OutputDevice.Element pageup;
    public OutputDevice.Element deleteforward;
    public OutputDevice.Element end;
    public OutputDevice.Element pagedown;
    public OutputDevice.Element right;
    public OutputDevice.Element left;
    public OutputDevice.Element down;
    public OutputDevice.Element up;
    public OutputDevice.Element kpnumlock;
    public OutputDevice.Element kpdivide;
    public OutputDevice.Element kpmultiply;
    public OutputDevice.Element kpsubtract;
    public OutputDevice.Element kpadd;
    public OutputDevice.Element kpenter;
    public OutputDevice.Element kp1;
    public OutputDevice.Element kp2;
    public OutputDevice.Element kp3;
    public OutputDevice.Element kp4;
    public OutputDevice.Element kp5;
    public OutputDevice.Element kp6;
    public OutputDevice.Element kp7;
    public OutputDevice.Element kp8;
    public OutputDevice.Element kp9;
    public OutputDevice.Element kp0;
    public OutputDevice.Element kppoint;
    public OutputDevice.Element nonusbackslash;
    public OutputDevice.Element kpequals;
    public OutputDevice.Element f13;
    public OutputDevice.Element f14;
    public OutputDevice.Element f15;
    public OutputDevice.Element f16;
    public OutputDevice.Element f17;
    public OutputDevice.Element f18;
    public OutputDevice.Element f19;
    public OutputDevice.Element f20;
    public OutputDevice.Element f21;
    public OutputDevice.Element f22;
    public OutputDevice.Element f23;
    public OutputDevice.Element f24;
    public OutputDevice.Element help;
    public OutputDevice.Element menu;
    public OutputDevice.Element mute;
    public OutputDevice.Element sysreq;
    public OutputDevice.Element @return;
    public OutputDevice.Element kpclear;
    public OutputDevice.Element kpdecimal;
    public OutputDevice.Element leftcontrol;
    public OutputDevice.Element leftshift;
    public OutputDevice.Element leftalt;
    public OutputDevice.Element leftgui;
    public OutputDevice.Element rightcontrol;
    public OutputDevice.Element rightshift;
    public OutputDevice.Element rightalt;
    public OutputDevice.Element rightgui;

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper() : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Keyboard>()))
    {
    }

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper(Func<OutputDevice, bool> predicate) : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Keyboard>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    public OutputDeviceWrapper(OutputDevice device) : base(device)
    {
      a = device[Keyboard.a];
      b = device[Keyboard.b];
      c = device[Keyboard.c];
      d = device[Keyboard.d];
      e = device[Keyboard.e];
      f = device[Keyboard.f];
      g = device[Keyboard.g];
      h = device[Keyboard.h];
      i = device[Keyboard.i];
      j = device[Keyboard.j];
      k = device[Keyboard.k];
      l = device[Keyboard.l];
      m = device[Keyboard.m];
      n = device[Keyboard.n];
      o = device[Keyboard.o];
      p = device[Keyboard.p];
      q = device[Keyboard.q];
      r = device[Keyboard.r];
      s = device[Keyboard.s];
      t = device[Keyboard.t];
      u = device[Keyboard.u];
      v = device[Keyboard.v];
      w = device[Keyboard.w];
      x = device[Keyboard.x];
      y = device[Keyboard.y];
      z = device[Keyboard.z];
      digit1 = device[Keyboard.digit1];
      digit2 = device[Keyboard.digit2];
      digit3 = device[Keyboard.digit3];
      digit4 = device[Keyboard.digit4];
      digit5 = device[Keyboard.digit5];
      digit6 = device[Keyboard.digit6];
      digit7 = device[Keyboard.digit7];
      digit8 = device[Keyboard.digit8];
      digit9 = device[Keyboard.digit9];
      digit0 = device[Keyboard.digit0];
      enter = device[Keyboard.enter];
      escape = device[Keyboard.escape];
      backspace = device[Keyboard.backspace];
      tab = device[Keyboard.tab];
      space = device[Keyboard.space];
      minus = device[Keyboard.minus];
      equals = device[Keyboard.equals];
      leftbracket = device[Keyboard.leftbracket];
      rightbracket = device[Keyboard.rightbracket];
      backslash = device[Keyboard.backslash];
      semicolon = device[Keyboard.semicolon];
      quote = device[Keyboard.quote];
      grave = device[Keyboard.grave];
      comma = device[Keyboard.comma];
      period = device[Keyboard.period];
      slash = device[Keyboard.slash];
      capslock = device[Keyboard.capslock];
      f1 = device[Keyboard.f1];
      f2 = device[Keyboard.f2];
      f3 = device[Keyboard.f3];
      f4 = device[Keyboard.f4];
      f5 = device[Keyboard.f5];
      f6 = device[Keyboard.f6];
      f7 = device[Keyboard.f7];
      f8 = device[Keyboard.f8];
      f9 = device[Keyboard.f9];
      f10 = device[Keyboard.f10];
      f11 = device[Keyboard.f11];
      f12 = device[Keyboard.f12];
      printscreen = device[Keyboard.printscreen];
      scrolllock = device[Keyboard.scrolllock];
      pause = device[Keyboard.pause];
      insert = device[Keyboard.insert];
      home = device[Keyboard.home];
      pageup = device[Keyboard.pageup];
      deleteforward = device[Keyboard.deleteforward];
      end = device[Keyboard.end];
      pagedown = device[Keyboard.pagedown];
      right = device[Keyboard.right];
      left = device[Keyboard.left];
      down = device[Keyboard.down];
      up = device[Keyboard.up];
      kpnumlock = device[Keyboard.kpnumlock];
      kpdivide = device[Keyboard.kpdivide];
      kpmultiply = device[Keyboard.kpmultiply];
      kpsubtract = device[Keyboard.kpsubtract];
      kpadd = device[Keyboard.kpadd];
      kpenter = device[Keyboard.kpenter];
      kp1 = device[Keyboard.kp1];
      kp2 = device[Keyboard.kp2];
      kp3 = device[Keyboard.kp3];
      kp4 = device[Keyboard.kp4];
      kp5 = device[Keyboard.kp5];
      kp6 = device[Keyboard.kp6];
      kp7 = device[Keyboard.kp7];
      kp8 = device[Keyboard.kp8];
      kp9 = device[Keyboard.kp9];
      kp0 = device[Keyboard.kp0];
      kppoint = device[Keyboard.kppoint];
      nonusbackslash = device[Keyboard.nonusbackslash];
      kpequals = device[Keyboard.kpequals];
      f13 = device[Keyboard.f13];
      f14 = device[Keyboard.f14];
      f15 = device[Keyboard.f15];
      f16 = device[Keyboard.f16];
      f17 = device[Keyboard.f17];
      f18 = device[Keyboard.f18];
      f19 = device[Keyboard.f19];
      f20 = device[Keyboard.f20];
      f21 = device[Keyboard.f21];
      f22 = device[Keyboard.f22];
      f23 = device[Keyboard.f23];
      f24 = device[Keyboard.f24];
      help = device[Keyboard.help];
      menu = device[Keyboard.menu];
      mute = device[Keyboard.mute];
      sysreq = device[Keyboard.sysreq];
      @return = device[Keyboard.@return];
      kpclear = device[Keyboard.kpclear];
      kpdecimal = device[Keyboard.kpdecimal];
      leftcontrol = device[Keyboard.leftcontrol];
      leftshift = device[Keyboard.leftshift];
      leftalt = device[Keyboard.leftalt];
      leftgui = device[Keyboard.leftgui];
      rightcontrol = device[Keyboard.rightcontrol];
      rightshift = device[Keyboard.rightshift];
      rightalt = device[Keyboard.rightalt];
      rightgui = device[Keyboard.rightgui];
    }
  }

}

} // End of namespace th.simio
