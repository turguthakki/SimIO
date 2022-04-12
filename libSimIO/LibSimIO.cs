/* ----------------------------------------------------------------------- *

    * LibSimIO.cs

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
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Runtime.InteropServices;

global using static th.simio.User32;
global using static th.simio.Kernel32;
global using static th.simio.Hid;
global using static th.simio.SimIO;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class SimIO
{
  // -------------------------------------------------------------------------
  public static event InputDeviceAttachmentNotification inputDevicesChanged = delegate {};
  public static event InputNotification onInput = delegate {};

  // -------------------------------------------------------------------------
  public static event OutputDeviceAttachmentNotification outputDevicesChanged = delegate {};

  // -------------------------------------------------------------------------
  public static IEnumerable<InputDevice> inputDevices => _inputDevices;
  static List<InputDevice> _inputDevices = new List<InputDevice>();

  // -------------------------------------------------------------------------
  public static IEnumerable<OutputDevice> outputDevices => _outputDevices;
  static List<OutputDevice> _outputDevices = new List<OutputDevice>();

  // -------------------------------------------------------------------------
  static SimIO()
  {
    RawInputDevice.init();
    SendInput.init();
    VJoy.init();
    update();
  }

  // -------------------------------------------------------------------------
  internal static void registerInputDevice(InputDevice device)
  {
    _inputDevices.Add(device);
    device.attachmentNotification += (d) => inputDevicesChanged(d);
    device.onInput += (d, e) => onInput(d, e);
    inputDevicesChanged(device);
  }

  // -------------------------------------------------------------------------
  internal static void registerOutputDevice(OutputDevice device)
  {
    _outputDevices.Add(device);
    device.attachmentNotification += (d) => outputDevicesChanged(d);
    outputDevicesChanged(device);
  }

  // -------------------------------------------------------------------------
  public static void update()
  {
    RawInputDevice.update();
  }
}


} // End of namespace th.simio
