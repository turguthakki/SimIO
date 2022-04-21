/* ----------------------------------------------------------------------- *

    * TypeUtils.cs

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
public static class TypeUtils
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if o is derived from or implements t
  /// </summary>
  public static bool isKindOf(this Type o, Type t) => t.IsAssignableFrom(o);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if o is derived from or implements t
  /// </summary>
  public static bool isKindOf<T>(this Type o) => o.isKindOf(typeof(T));

  // -------------------------------------------------------------------------
  /// <summary>
  /// Reutrns if o is derived from or implements t
  /// </summary>
  public static bool isKindOf(this object o, Type t) => o.GetType().isKindOf(t);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if o is derived from or implements T
  /// </summary>
  public static bool isKindOf<T>(this object o) => o.GetType().isKindOf<T>();

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if o is derived from or implements any of t
  /// </summary>
  public static bool isKindOf(this object o, params Type []t) => o.GetType().isKindOf(t);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if o is derived from or implements any of t
  /// </summary>
  public static bool isKindOf(this Type o, params Type []t)
  {
    for (int i = 0; i < t.Length; i++) {
      if (o.isKindOf(t))
        return true;
    }
    return false;
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if type is nullable
  /// </summary>
  public static bool isNullable(this Type type) => !type.IsValueType || Nullable.GetUnderlyingType(type) != null;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns classes derived from type
  /// </summary>
  public static IEnumerable<Type> subTypes(this Type type)
  {
    return type.Assembly.GetTypes().Where(t => !t.IsAbstract && t != type && t.isKindOf(type));
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns classes derived from type
  /// </summary>
  /// <param name="type"></param>
  /// <param name="allowAbstractClasses">Includes abstract classes when set</param>
  /// <param name="allowConcreteClasses">Includes concrete classes when set</param>
  public static IEnumerable<Type> subTypes(this Type type, bool allowAbstractClasses, bool allowConcreteClasses)
  {
    return type.Assembly.GetTypes().Where(t => (t.IsAbstract ? allowAbstractClasses : allowConcreteClasses) && t != type && t.isKindOf(type));
  }
}

} // End of namespace th.simio
