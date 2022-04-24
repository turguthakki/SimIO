/* ----------------------------------------------------------------------- *

    * BidirectionalAxis.cs

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
/// Abstract base class for absolute axis modifiers
/// </summary>
public abstract class AbsoluteAxisModifier : InputModifier
{
  // -------------------------------------------------------------------------
  public override bool isValid => _isValid;
  public override float minimumValue => _minimumValue;
  public override float maximumValue => _maximumValue;
  public override float value => position;
  public override float position => _position;
  public override float motion => _motion;

  // -------------------------------------------------------------------------
  bool _isValid;
  protected float _minimumValue;
  protected float _maximumValue;
  protected float _position;
  protected float _motion;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Constructor
  /// </summary>
  /// <param name="parent">Parent element</param>
  public AbsoluteAxisModifier(InputDevice.Element parent) : base(parent)
  {
    if (!parent.isAbsolute || parent.isCyclic) {
      throw new System.InvalidOperationException("Failed creating AbsoluteAxisModifier input modifier. Parent element must be absolute and not cyclic.");
    }

    _minimumValue = parent.minimumValue;
    _maximumValue = parent.maximumValue;
    SimIO.onBeforeUpdate += () => _motion = 0;
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Calculate new value here
  /// </summary>
  protected abstract float calculateNewValue();

  // -------------------------------------------------------------------------
  protected override void onInputReceived()
  {
    float newValue = calculateNewValue();
    if (newValue != _position || parent.isValid != _isValid) {
      _motion = newValue - _position;
      _position = newValue;
      _isValid = parent.isValid;
      notifyInput();
    }
  }
}

} // End of namespace th.SimIO
