/* ----------------------------------------------------------------------- *

    * SendInputMouse.cs

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

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class SendInputMouse : OutputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal protected class SendInputMouseElement : OutputDevice.Element
  {
    // -----------------------------------------------------------------------
    INPUT[] data;

    // -----------------------------------------------------------------------
    public OutputDevice device {get; protected set;}
    public ElementIdentifier id {get; protected set;}

    public bool isCyclic => false;
    public bool isRelative {get; private set;}
    public bool isAbsolute => !isRelative;

    public float minimumValue => 0.0f;
    public float maximumValue => isRelative ? 0 : 1.0f;

    public bool isValid => true;

    Func<float> getValue;
    Func<float, MOUSEINPUT> setValue;

    // -----------------------------------------------------------------------
    public float value
    {
      get => getValue();
      set {
        if (value != getValue()) {
          data[0].mi = setValue(value);
          SendInput(1, data, Marshal.SizeOf<INPUT>());
        }
      }
    }

    // -----------------------------------------------------------------------
    internal SendInputMouseElement(OutputDevice device, ElementIdentifier id, bool isRelative, Func<float, MOUSEINPUT> setValue, Func<float> getValue = null)
    {
      this.device = device;
      this.id = id;
      this.isRelative = isRelative;
      this.getValue = getValue is null ? () => 0.0f : getValue;
      this.setValue = setValue;
      this.data = new INPUT[] {
        new INPUT() {
          type = INPUT_MOUSE
        }
      };
    }
  }

  // -------------------------------------------------------------------------
  protected SendInputMouseElement[] _elements;
  SendInputMouseElement xPosition;
  SendInputMouseElement yPosition;

  // -------------------------------------------------------------------------
  public string deviceIdentifier => "sendinput:mouse";

  // -------------------------------------------------------------------------
  public Type deviceType => typeof(InputDevice.DeviceType.Mouse);

  // -------------------------------------------------------------------------
  public bool isAttached => true;

  // -------------------------------------------------------------------------
  public bool isActive {get; set;}

  // -------------------------------------------------------------------------
  public IEnumerable<OutputDevice.Element> elements => _elements;

  // -------------------------------------------------------------------------
  public event OutputDeviceAttachmentNotification attachmentNotification = delegate {};

  // -------------------------------------------------------------------------
  internal SendInputMouse()
  {
    _elements = new SendInputMouseElement[] {
      xPosition = new SendInputMouseElement(this, Mouse.xPosition, false,
        (float v) => new MOUSEINPUT() {
          dx = (int) (((v - GetSystemMetrics(SM_XVIRTUALSCREEN)) * 65536.0f) / GetSystemMetrics(SM_CXVIRTUALSCREEN) + 65536.0f / (GetSystemMetrics(SM_CXVIRTUALSCREEN))),
          dy = (int) (((yPosition.value - GetSystemMetrics(SM_YVIRTUALSCREEN)) * 65536.0f) / GetSystemMetrics(SM_CYVIRTUALSCREEN) + 65536.0f / (GetSystemMetrics(SM_CYVIRTUALSCREEN))),
          dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_VIRTUALDESK
        },
        () => {
          POINT pt = new POINT();
          GetCursorPos(ref pt);
          return (float) pt.x;
        }
      ),
      yPosition = new SendInputMouseElement(this, Mouse.yPosition, false,
        (float v) => new MOUSEINPUT() {
          dx = (int) (((xPosition.value - GetSystemMetrics(SM_XVIRTUALSCREEN)) * 65536.0f) / GetSystemMetrics(SM_CXVIRTUALSCREEN) + 65536.0f / (GetSystemMetrics(SM_CXVIRTUALSCREEN))),
          dy = (int) (((v - GetSystemMetrics(SM_YVIRTUALSCREEN)) * 65536.0f) / GetSystemMetrics(SM_CYVIRTUALSCREEN) + 65536.0f / (GetSystemMetrics(SM_CYVIRTUALSCREEN))),
          dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_VIRTUALDESK
        },
        () => {
          POINT pt = new POINT();
          GetCursorPos(ref pt);
          return (float) pt.y;
        }
      ),
      new SendInputMouseElement(this, Mouse.xAxis, true, (float v) => new MOUSEINPUT() {
        dx = (int) v,
        dwFlags = MOUSEEVENTF_MOVE
      }),
      new SendInputMouseElement(this, Mouse.yAxis, true, (float v) => new MOUSEINPUT() {
        dy = (int) v,
        dwFlags = MOUSEEVENTF_MOVE
      }),
      new SendInputMouseElement(this, Mouse.leftButton, false,
        (float v) => new MOUSEINPUT() {
          dwFlags = v > 0 ? MOUSEEVENTF_LEFTDOWN : MOUSEEVENTF_LEFTUP
        },
        () => ((GetKeyState(VK_LBUTTON) & 0x8000) == 0x8000) ? 1.0f : 0.0f
      ),
      new SendInputMouseElement(this, Mouse.rightButton, false,
        (float v) => new MOUSEINPUT() {
          dwFlags = v > 0 ? MOUSEEVENTF_RIGHTDOWN : MOUSEEVENTF_RIGHTUP
        },
        () => ((GetKeyState(VK_RBUTTON) & 0x8000) == 0x8000) ? 1.0f : 0.0f
      ),
      new SendInputMouseElement(this, Mouse.middleButton, false,
        (float v) => new MOUSEINPUT() {
          dwFlags = v > 0 ? MOUSEEVENTF_MIDDLEDOWN : MOUSEEVENTF_MIDDLEUP
        },
        () => ((GetKeyState(VK_MBUTTON) & 0x8000) == 0x8000) ? 1.0f : 0.0f
      ),
      new SendInputMouseElement(this, Mouse.forwardButton, false,
        (float v) => new MOUSEINPUT() {
          mouseData = 1,
          dwFlags = v > 0 ? MOUSEEVENTF_XDOWN : MOUSEEVENTF_XUP
        },
        () => ((GetKeyState(VK_XBUTTON1) & 0x8000) == 0x8000) ? 1.0f : 0.0f
      ),
      new SendInputMouseElement(this, Mouse.leftButton, false,
        (float v) => new MOUSEINPUT() {
          mouseData = 2,
          dwFlags = v > 0 ? MOUSEEVENTF_XDOWN : MOUSEEVENTF_XUP
        },
        () => ((GetKeyState(VK_XBUTTON2) & 0x8000) == 0x8000) ? 1.0f : 0.0f
      ),
      new SendInputMouseElement(this, Mouse.wheelX, true,
        (float v) => new MOUSEINPUT() {
          mouseData = v >= 0 ? ((UInt32) (v * 120.0f)) : (UInt32) (0xffffffff - (UInt32) (v * 120.0f)),
          dwFlags = MOUSEEVENTF_HWHEEL
        }
      ),
      new SendInputMouseElement(this, Mouse.wheelY, true,
        (float v) => new MOUSEINPUT() {
          mouseData = v >= 0 ? ((UInt32) (v * 120.0f)) : (UInt32) (0xffffffff - (UInt32) (v * 120.0f)),
          dwFlags = MOUSEEVENTF_WHEEL
        }
      ),

    };
  }

}

} // End of namespace th.simio
