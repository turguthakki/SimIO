/* ----------------------------------------------------------------------- *

    * InputDevice.cs

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

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Delegate type for device attachment / deteachment notifications. Fired when an input device attached to or detached from the system.
/// </summary>
/// <param name="device">The device</param>
public delegate void InputDeviceAttachmentNotification(InputDevice device);
/// <summary>
/// Delegate type for input notifications.
/// </summary>
/// <param name="device">Input device</param>
/// <param name="element">Input element</param>
public delegate void InputNotification(InputDevice device, InputDevice.Element element);

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Input device interface
/// </summary>
public partial interface InputDevice
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Unique identification string for device.
  /// </summary>
  /// <value></value>
  string deviceIdentifier {get;}

  /// <summary>
  /// Hardware type descriptor.
  /// Must be derived from InputDevice.DeviceType
  /// </summary>
  Type deviceType {get;}

  /// <summary>
  /// Indicates if the device is currently attached
  /// </summary>
  bool isAttached {get;}

  /// <summary>
  /// Controlled by code. When set to false disables all input from device
  /// </summary>
  bool isActive {get; set;}

  /// <summary>
  /// Input elements on the device
  /// </summary>
  IEnumerable<Element> elements {get;}

  /// <summary>
  /// Fired when device attached or detached.
  /// </summary>
  event InputDeviceAttachmentNotification attachmentNotification;
  /// <summary>
  /// Fired when an event is occured on any element of device
  /// </summary>
  event InputNotification onInput;
}

} // End of namespace th.simio
