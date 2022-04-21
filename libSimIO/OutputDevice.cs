/* ----------------------------------------------------------------------- *

    * OutputDevice.cs

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
public delegate void OutputDeviceAttachmentNotification(OutputDevice device);

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Interface for emulated input device. (Eg: Output device)
/// </summary>
public partial interface OutputDevice
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Unique device identifier string
  /// </summary>
  string deviceIdentifier {get;}

  /// <summary>
  /// Hardware type descriptor.
  /// Must be derived from InputDevice.DeviceType
  /// </summary>
  Type deviceType {get;}

  /// <summary>
  /// Indicates if the device is attached
  /// </summary>
  bool isAttached {get;}

  /// <summary>
  /// Controlled by code. When set to false disables all output to device
  /// </summary>
  bool isActive {get; set;}

  /// <summary>
  /// Output elements on the device.
  /// </summary>
  IEnumerable<Element> elements {get;}

  /// <summary>
  /// Fired when device attached or detached.
  /// </summary>
  event OutputDeviceAttachmentNotification attachmentNotification;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first element matching the given identifier or null.
  /// </summary>
  Element this[ElementIdentifier i] => elements.FirstOrDefault(e => e.id == i);

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public abstract class Wrapper : OutputDevice
  {
    public OutputDevice device {get; private set;}
    public string deviceIdentifier => device.deviceIdentifier;
    public Type deviceType => device.deviceType;
    public bool isAttached => device.isAttached;
    public bool isActive {get => device.isActive; set => device.isActive = value;}
    public IEnumerable<Element> elements => device.elements;
    public event OutputDeviceAttachmentNotification attachmentNotification {add => device.attachmentNotification += value; remove => device.attachmentNotification -= value;}
    public Element this[ElementIdentifier i] => device[i];

    // -----------------------------------------------------------------------
    public Wrapper(OutputDevice device)
    {
      this.device = device;
    }
  }
}

} // End of namespace th.simio
