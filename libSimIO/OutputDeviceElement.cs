/* ----------------------------------------------------------------------- *

    * OutputDeviceElement.cs

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
public partial interface OutputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  /// <summary>
  /// Output element.
  /// Interface for an emulated input element on the device such as mouse wheel, x or y axis or a button.
  /// </summary>
  public interface Element
  {
    /// <summary>
    /// Output device
    /// </summary>
    OutputDevice device {get;}

    /// <summary>
    /// Identifier.
    /// Used to identify whan an element is used for such as Keyboard.enter
    /// </summary>
    ElementIdentifier id {get;}

    /// <summary>
    /// Indicates if the element is cyclic. A cyclic input element reports an absolute value but can cycle.
    /// </summary>
    bool isCyclic {get;}

    /// <summary>
    /// Indicates if element accepts relative values such as mouse axes.
    /// </summary>
    bool isRelative {get;}

    /// <summary>
    /// Indicates if element accepts absolute values such as joystick axes or buttons or keyboard keys
    /// </summary>
    bool isAbsolute {get;}

    /// <summary>
    /// Minimum value.
    /// On relative elements, minimum and maximum values has no meaning and is usually zero.
    /// </summary>
    float minimumValue {get;}

    /// <summary>
    /// Minimum value.
    /// On relative elements, minimum and maximum values has no meaning and is usually zero.
    /// </summary>
    float maximumValue {get;}

    /// <summary>
    /// Indicates if the values of value, position and motion variables have valid values.
    /// As an example a pov hat should report invalid values when user is not interacting with it.
    /// </summary>
    bool isValid => true;

    /// <summary>
    /// Used to send input to emulation. Depending on if the element is relative or absolute accepts relative or absolute value
    /// </summary>
    float value {get; set;}
  }
}

} // End of namespace th.simio
