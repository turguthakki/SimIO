/* ----------------------------------------------------------------------- *

    * ButtonModififer.cs

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
/// Creates an button modifier from a given element
/// </summary>
public class ButtonModififer : InputModifier
{
  public override bool isCyclic => false;
  public override bool isRelative => false;
  public override bool isAbsolute => true;
  public override bool isValid => true;
  public override bool isBidirectional => false;

  public override float minimumValue => 0.0f;
  public override float maximumValue => 1.0f;

  /// <summary>
  /// Returns 1.0 when the element considered down and 0 when up
  /// </summary>
  public override float value => _position;

  /// <summary>
  /// Returns 1.0 when the element considered down and 0 when up
  /// </summary>
  public override float position => _position;
  public override float motion => _motion;

  /// <summary>
  /// Returns if the element is currently considered down.
  /// </summary>
  public virtual bool isDown => _position == 1.0f;

  /// <summary>
  /// Returns if the element became "down" in last update
  /// </summary>
  public virtual bool isPressed => _motion == 1.0f;
  /// <summary>
  /// Returns if the element became "up" in the last update
  /// </summary>
  public virtual bool isReleased => _motion == -1.0f;

  protected float _position;
  protected float _motion;
  protected float low;
  protected float high;

  // -------------------------------------------------------------------------
  public ButtonModififer(InputDevice.Element parent, float start = 0.5f, float end = 1.0f) : base(parent)
  {
    low = mathf.min(start, end);
    high = mathf.max(start, end);
    SimIO.onBeforeUpdate += () => _motion = 0;
  }

  // -------------------------------------------------------------------------
  protected override void onInputReceived()
  {
    float newValue = parent.isValid ? ((parent.value >= low && parent.value <= high) ? 1.0f : 0.0f) : 0.0f;
    if (newValue != _position) {
      _motion = newValue - _position;
      _position = newValue;
      notifyInput();
    }
  }
}

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class ButtonModififerHelpers
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Creates an input modifier that acts like a button
  /// </summary>
  public static ButtonModififer button(this InputDevice.Element parent, float start = 0.5f, float end = 1.0f) => new ButtonModififer(parent, start, end);
}


} // End of namespace th.SimIO
