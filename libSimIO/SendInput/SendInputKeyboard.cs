/* ----------------------------------------------------------------------- *

    * SendInputKeyboard.cs

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
public partial class SendInputKeyboard : OutputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  internal protected class SendInputKeyboardElement : OutputDevice.Element
  {
    // -----------------------------------------------------------------------
    float _value = 0;
    INPUT[] data;

    // -----------------------------------------------------------------------
    public OutputDevice device {get; protected set;}
    public ElementIdentifier id {get; protected set;}

    public bool isCyclic => false;
    public bool isRelative => false;
    public bool isAbsolute => false;

    public float minimumValue => 0.0f;
    public float maximumValue => 1.0f;

    public bool isValid => true;

    // -----------------------------------------------------------------------
    public float value
    {
      get => _value;
      set {
        _value = value;
        data[0].ki.dwFlags = KEYEVENTF_SCANCODE | (value == 0 ? KEYEVENTF_KEYUP : 0);
        SendInput(1, data, Marshal.SizeOf<INPUT>());
      }
    }

    // -----------------------------------------------------------------------
    internal SendInputKeyboardElement(OutputDevice device, ElementIdentifier id, ushort scanCode)
    {
      this.device = device;
      this.id = id;
      data = new INPUT[] {
        new INPUT() {
          type = INPUT_KEYBOARD,
          ki = new KEYBDINPUT() {
            wScan = scanCode
          }
        }
      };
    }
  }
  // -------------------------------------------------------------------------
  protected SendInputKeyboardElement[] _elements;

  // -------------------------------------------------------------------------
  public string deviceIdentifier => "sendinput:keyboard";

  // -------------------------------------------------------------------------
  public Type deviceType => typeof(InputDevice.DeviceType.Keyboard);

  // -------------------------------------------------------------------------
  public bool isAttached => true;

  // -------------------------------------------------------------------------
  public bool isActive {get; set;}

  // -------------------------------------------------------------------------
  public IEnumerable<OutputDevice.Element> elements => _elements;

  // -------------------------------------------------------------------------
  public event OutputDeviceAttachmentNotification attachmentNotification = delegate {};

  // -------------------------------------------------------------------------
  internal SendInputKeyboard()
  {
    List<SendInputKeyboardElement> elements = new List<SendInputKeyboardElement>() {};

    foreach(var e in RawInputKeyboard.scancodeTranslationTable) {
      HidIdentifier identifier = Keyboard.keys.FirstOrDefault(k => k.usage == (HidUsage.Usage) e.Value);
      if (identifier is not null) {
        elements.Add(new SendInputKeyboardElement(this, identifier, (ushort) e.Key));
      }
    }

    _elements = elements.ToArray();
  }
}

} // End of namespace th.simio
