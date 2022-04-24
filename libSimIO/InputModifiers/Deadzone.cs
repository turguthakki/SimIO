/* ----------------------------------------------------------------------- *

    * Deadzone.cs

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
/// Input modifier that ignores some portion of input
/// </summary>
public class Deadzone : AbsoluteAxisModifier
{
  // -------------------------------------------------------------------------
  float low;
  float high;
  float midpoint;

  // -------------------------------------------------------------------------
  public Deadzone(InputDevice.Element parent, float start, float end) : base(parent)
  {
    low = mathf.min(start, end);
    high = mathf.max(start, end);

    if (low == minimumValue)
      midpoint = minimumValue;
    else if (high == maximumValue)
      midpoint = maximumValue;
    else
      midpoint = (low + high) * 0.5f;
  }


  // -------------------------------------------------------------------------
  protected override float calculateNewValue()
  {
    if (parent.value < low) {
      return mathf.lerp(midpoint, minimumValue, mathf.inverseLerp(low, minimumValue, parent.value));;
    }
    else if (parent.value > high) {
      return mathf.lerp(midpoint, maximumValue, mathf.inverseLerp(high, maximumValue, parent.value));
    }
    return midpoint;
  }
}

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class DeadzoneHelpers
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Creates an input modifier that ignores some portion of input
  /// </summary>
  public static Deadzone deadzone(this InputDevice.Element parent, float start, float end) => new Deadzone(parent, start, end);
}

} // End of namespace th.SimIO
