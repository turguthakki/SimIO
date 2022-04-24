/* ----------------------------------------------------------------------- *

    * Math.cs

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
using System.Runtime.CompilerServices;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class mathf
{
  // -------------------------------------------------------------------------
  public static float lerp(float a, float b, float v) => a * (1 - v) + b * v;

  // -------------------------------------------------------------------------
  public static float inverseLerp(float a, float b, float v) => (v - a) / (b - a);

  // -------------------------------------------------------------------------
  public static float clamp(float v, float min, float max) => (float) Math.Clamp(v, min, max);

  // -------------------------------------------------------------------------
  public static float clamp01(float v) => (float) Math.Clamp(v, 0, 1);

  public const float e = 2.71828175F;
  public const float pi = 3.14159274F;
  public const float tau = 6.28318548F;
  public static float abs(float x) => System.MathF.Abs(x);
  public static float acos(float x) => System.MathF.Acos(x);
  public static float acosh(float x) => System.MathF.Acosh(x);
  public static float asin(float x) => System.MathF.Asin(x);
  public static float asinh(float x) => System.MathF.Asinh(x);
  public static float atan(float x) => System.MathF.Atan(x);
  public static float atan2(float y, float x) => System.MathF.Atan2(x, y);
  public static float atanh(float x) => System.MathF.Atanh(x);
  public static float bitDecrement(float x) => System.MathF.BitDecrement(x);
  public static float bitIncrement(float x) => System.MathF.BitIncrement(x);
  public static float cbrt(float x) => System.MathF.Cbrt(x);
  public static float ceiling(float x) => System.MathF.Ceiling(x);
  public static float copySign(float x, float y) => System.MathF.CopySign(x, y);
  public static float cos(float x) => System.MathF.Cos(x);
  public static float cosh(float x) => System.MathF.Cosh(x);
  public static float exp(float x) => System.MathF.Exp(x);
  public static float floor(float x) => System.MathF.Floor(x);
  public static float fusedMultiplyAdd(float x, float y, float z) => System.MathF.FusedMultiplyAdd(x, y, z);
  public static float iEEERemainder(float x, float y) => System.MathF.IEEERemainder(x, y);
  public static int iLogB(float x) => System.MathF.ILogB(x);
  public static float log(float x, float y) => System.MathF.Log(x);
  public static float log(float x) => System.MathF.Log(x);
  public static float log10(float x) => System.MathF.Log10(x);
  public static float log2(float x) => System.MathF.Log2(x);
  public static float max(float x, float y) => System.MathF.Max(x, y);
  public static float maxMagnitude(float x, float y) => System.MathF.MaxMagnitude(x, y);
  public static float min(float x, float y) => System.MathF.Min(x, y);
  public static float minMagnitude(float x, float y) => System.MathF.MinMagnitude(x, y);
  public static float pow(float x, float y) => System.MathF.Pow(x, y);
  public static float reciprocalEstimate(float x) => System.MathF.ReciprocalEstimate(x);
  public static float reciprocalSqrtEstimate(float x) => System.MathF.ReciprocalSqrtEstimate(x);
  public static float round(float x, MidpointRounding mode) => System.MathF.Round(x);
  public static float round(float x, int digits, MidpointRounding mode) => System.MathF.Round(x);
  public static float round(float x, int digits) => System.MathF.Round(x);
  public static float round(float x) => System.MathF.Round(x);
  public static float scaleB(float x, int n) => System.MathF.ScaleB(x, n);
  public static int sign(float x) => System.MathF.Sign(x);
  public static float sin(float x) => System.MathF.Sin(x);
  public static (float sin, float cos) sinCos(float x) => MathF.SinCos(x);
  public static float sinh(float x) => System.MathF.Sinh(x);
  public static float sqrt(float x) => System.MathF.Sqrt(x);
  public static float tan(float x) => System.MathF.Tan(x);
  public static float tanh(float x) => System.MathF.Tanh(x);
  public static float truncate(float x) => System.MathF.Truncate(x);
}

} // End of namespace th.SimIO.mathf
