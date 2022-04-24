/* ----------------------------------------------------------------------- *

    * FunctionalModifier.cs

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
#nullable enable

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Input modifier that allows for lambda flavoured custom modifications
/// </summary>
public class FunctionalModifier : InputModifier
{
  public override ElementIdentifier identifier => _identifier;
  public override bool isCyclic => _isCyclic;
  public override bool isRelative => _isRelative;
  public override bool isAbsolute => !isRelative;
  public override bool isValid => _isValid;
  public override bool isBidirectional => _isBidirectional;
  public override float minimumValue => _minimumValue;
  public override float maximumValue => _maximumValue;
  public override float value => _value;
  public override float position => _position;
  public override float motion => _motion;

  protected ElementIdentifier _identifier;
  protected bool _isCyclic;
  protected bool _isRelative;
  protected bool _isValid;
  protected bool _isBidirectional;
  protected float _minimumValue;
  protected float _maximumValue;

  Func<InputDevice.Element, float> function;
  float _value;
  float _position;
  float _motion;

  // -------------------------------------------------------------------------
  public FunctionalModifier(InputDevice.Element parent, Func<InputDevice.Element, float> function, ElementIdentifier? identifier = null, bool? isCyclic = null, bool? isRelative = null, bool? isBidirectional = null, float? minimumValue = null, float? maximumValue = null) : base(parent)
  {
    this.function = function;
    _identifier =  identifier == null ? parent.identifier : identifier;
    _isCyclic =  isCyclic == null ? parent.isCyclic : isCyclic.Value;
    _isRelative =  isRelative == null ? parent.isRelative : isRelative.Value;
    _isBidirectional =  isBidirectional == null ? parent.isBidirectional : isBidirectional.Value;
    _minimumValue =  minimumValue == null ? parent.minimumValue : minimumValue.Value;
    _maximumValue =  maximumValue == null ? parent.maximumValue : maximumValue.Value;
    if (!_isRelative)
      SimIO.onBeforeUpdate += () => _motion = 0;
  }

  // -------------------------------------------------------------------------
  protected override void onInputReceived()
  {
    bool oldIsValid = parent.isValid;
    _isValid = parent.isValid;
    float newValue = function(parent);
    if (_isRelative) {
      if (_motion != newValue || isValid != oldIsValid) {
        _value = _motion = newValue;
        _position = 0;
        notifyInput();
      }
    }
    else {
      if (newValue != position || this.isValid != oldIsValid) {
        _motion = newValue - position;
        _value = _position = newValue;
        notifyInput();
      }
    }
  }
}

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class FunctionalModifierHelpers
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Creates an input modifier that allows for lambda flavoured custom modifications
  /// </summary>
  public static FunctionalModifier functionalModifier(this InputDevice.Element parent, Func<InputDevice.Element, float> function, ElementIdentifier? identifier = null, bool? isCyclic = null, bool? isRelative = null, bool? isBidirectional = null, float? minimumValue = null, float? maximumValue = null) => new FunctionalModifier(parent, function, identifier, isCyclic, isRelative, isBidirectional, minimumValue, maximumValue);
}

#nullable disable
} // End of namespace th.SimIO
