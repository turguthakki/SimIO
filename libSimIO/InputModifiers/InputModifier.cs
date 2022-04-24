/* ----------------------------------------------------------------------- *

    * InputModifier.cs

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
/// <summary>
/// Abstract base class for input modifiers.
/// </summary>
public abstract class InputModifier : InputDevice.Element
{
  public InputDevice device => root.device;
  public virtual ElementIdentifier identifier => parent.identifier;
  public virtual bool isCyclic => parent.isCyclic;
  public virtual bool isRelative => parent.isRelative;
  public virtual bool isAbsolute => parent.isAbsolute;
  public virtual bool isValid => parent.isValid;
  public virtual bool isBidirectional => parent.isBidirectional;

  public virtual float minimumValue => parent.minimumValue;
  public virtual float maximumValue => parent.maximumValue;
  public virtual float value => parent.value;
  public virtual float position => parent.position;
  public virtual float motion => parent.motion;
  public event InputNotification onInput = delegate {};

  /// <summary>
  /// Previous element in chain
  /// </summary>
  public InputDevice.Element parent {get; private set;}

  /// <summary>
  /// Actual input element on the device
  /// </summary>
  public InputDevice.Element root {get; private set;}

  // -------------------------------------------------------------------------
  /// <summary>
  /// Constructor
  /// </summary>
  /// <param name="parent">Parent input element in chain</param>
  protected InputModifier(InputDevice.Element parent)
  {
    this.parent = parent;
    for (root = parent; root.isKindOf<InputModifier>(); root = (root as InputModifier).parent) {/* Do nothing */}
    parent.onInput += (d, e) => onInputReceived();
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Invoke this in onInputReceived method to trigger onInput event
  /// </summary>
  protected void notifyInput() => onInput(device, this);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Invoked when input received in parent element
  /// </summary>
  protected abstract void onInputReceived();
}

} // End of namespace th.SimIO
