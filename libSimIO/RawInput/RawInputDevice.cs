/* ----------------------------------------------------------------------- *

    * RawInputDevice.cs

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
using static System.Runtime.InteropServices.Marshal;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public abstract partial class RawInputDevice : InputDevice
{
  // -------------------------------------------------------------------------
  public string deviceIdentifier {get; private set;}
  public Type deviceType {get; protected set;}
  public bool isActive {get; set;}
  public IEnumerable<InputDevice.Element> elements => _elements;

  public event InputDeviceAttachmentNotification attachmentNotification = delegate {};
  public event InputNotification onInput = delegate {};

  // -------------------------------------------------------------------------
  bool _isAttached = true;
  public bool isAttached
  {
    get => _isAttached;
    protected set {
      if (value != _isAttached) {
        _isAttached = value;
        attachmentNotification(this);
      }
    }
  }

  // -------------------------------------------------------------------------
  public string manufacturerString {get; private set;}
  public string productString {get; private set;}

  // -------------------------------------------------------------------------
  protected IntPtr deviceHandle;
  protected RID_DEVICE_INFO deviceInfo;
  protected RawInputDeviceElement[] _elements;

  // -------------------------------------------------------------------------
  protected RawInputDevice(IntPtr deviceHandle, string devicePath, RID_DEVICE_INFO deviceInfo)
  {
    this.deviceHandle = deviceHandle;
    deviceIdentifier = devicePath;
    this.deviceInfo = deviceInfo;

    // Strings
    {
      IntPtr fileHandle = CreateFile(devicePath, (deviceInfo.dwType == RIM_TYPEHID) ? (GENERIC_READ | GENERIC_WRITE) : 0, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

      IntPtr stringBuffer = Marshal.AllocHGlobal((126 + 1) * 2);

      HidD_GetManufacturerString(fileHandle, stringBuffer, 126 * 2);
      manufacturerString = Marshal.PtrToStringUni(stringBuffer);

      HidD_GetProductString(fileHandle, stringBuffer, 126 * 2);
      productString = Marshal.PtrToStringUni(stringBuffer);

      Marshal.FreeHGlobal(stringBuffer);
      CloseHandle(fileHandle);
    }
  }

  // -------------------------------------------------------------------------
  internal void notifyInput(InputDevice device, InputDevice.Element elem)
  {
    onInput(device, elem);
  }

  // -------------------------------------------------------------------------
  internal unsafe abstract void update(RAWINPUT *data);
}

} // End of namespace th.simio
