/* ----------------------------------------------------------------------- *

    * InputDeviceType.cs

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

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public partial interface InputDevice
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Descriptor type for hardware type
  /// </summary>
  public interface DeviceType {
    /// <summary>
    /// Used for queries
    /// </summary>
    public interface DontCare : DeviceType {};

    /// <summary>
    /// Keyboard
    /// </summary>
    public interface Keyboard : DeviceType {};

    /// <summary>
    /// Pointer device. Eg: Mouse or Touch
    /// </summary>
    public interface PointerDevice : DeviceType {};

    /// <summary>
    /// Mouse
    /// </summary>
    public interface Mouse : PointerDevice {};

    /// <summary>
    /// Joystick devices
    /// </summary>
    public interface Joystick : DeviceType {};

    /// <summary>
    /// Gamepad.
    /// </summary>
    public interface Gamepad : Joystick {};
  };
}

} // End of namespace th.simio
