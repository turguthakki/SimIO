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

global using static th.SimIO.User32DLL;
global using static th.SimIO.Kernel32DLL;
global using static th.SimIO.HidDLL;
global using static th.SimIO.SimIO;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Main interface class
/// </summary>
public class SimIO
{
  public delegate void UpdateNotification();

  // -------------------------------------------------------------------------
  /// <summary>
  /// Fired when an input device attached to or detached from the system.
  /// </summary>
  public static event InputDeviceAttachmentNotification inputDevicesChanged = delegate {};
  /// <summary>
  /// Fired when a input occured any attached devices to system
  /// </summary>
  public static event InputNotification onInput = delegate {};

  // -------------------------------------------------------------------------
  /// <summary>
  /// Fired when an output device is attached or detached
  /// </summary>
  public static event OutputDeviceAttachmentNotification outputDevicesChanged = delegate {};

  // -------------------------------------------------------------------------
  /// <summary>
  /// Fired before update starts
  /// </summary>
  public static event UpdateNotification onBeforeUpdate = delegate {};

  // -------------------------------------------------------------------------
  /// <summary>
  /// Fired after update ends
  /// </summary>
  public static event UpdateNotification onAfterUpdate = delegate {};

  // -------------------------------------------------------------------------
  /// <summary>
  /// List of all known input devices
  /// </summary>
  public static IEnumerable<InputDevice> inputDevices => _inputDevices;
  static List<InputDevice> _inputDevices = new List<InputDevice>();

  // -------------------------------------------------------------------------
  /// <summary>
  /// List of all known output devices
  /// </summary>
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
    onBeforeUpdate();
    RawInputDevice.update();
    onAfterUpdate();
  }
}


} // End of namespace th.simio
