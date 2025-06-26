/* ----------------------------------------------------------------------- *

    * ObjectUtils.cs

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
using System.Reflection;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class ObjectUtils
{
  static readonly object[] emptyParameterSet = new object[]{};

  // -------------------------------------------------------------------------
  public static object shallowCopy(this object obj)
    => obj.GetType().GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(obj, emptyParameterSet);

  // -------------------------------------------------------------------------
  public static T shallowCopy<T>(this T obj)
    => (T) shallowCopy((object) obj);

  // -------------------------------------------------------------------------
  // https://www.codeproject.com/Articles/38270/Deep-copy-of-objects-in-C
  public static object deepCopy(this object obj)
  {
    if (obj == null)
      return null;

    Type type = obj.GetType();

    if (type.IsValueType || type == typeof(string)) {
      return obj;
    }
    else if (type.IsArray) {
      Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));
      var array = obj as Array;
      Array copied = Array.CreateInstance(elementType, array.Length);

      for (int i = 0; i < array.Length; i++) {
        copied.SetValue(deepCopy(array.GetValue(i)), i);
      }
      return Convert.ChangeType(copied, obj.GetType());
    }
    else if (type.IsClass) {
      object toret = Activator.CreateInstance(obj.GetType());
      FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
      foreach (FieldInfo field in fields) {
        object fieldValue = field.GetValue(obj);
        if (fieldValue == null)
          continue;
        field.SetValue(toret, deepCopy(fieldValue));
      }
      return toret;
    }
    else
      throw new ArgumentException("Unknown type");
  }

  // -------------------------------------------------------------------------
  public static T deepCopy<T>(this T obj)
    => (T) deepCopy((object) obj);

  // -------------------------------------------------------------------------
  public static bool deepEquals(this object a, object b)
  {
    if (ReferenceEquals(a, b))
      return true;
    else if (a == null && b == null)
      return true;
    else if (a == null || b == null || a.GetType() != b.GetType())
      return false;

    Type type = a.GetType();

    if (type.IsValueType || type == typeof(string)) {
      return a.Equals(b);
    }
    else if (type.IsArray) {
      Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));

      Array aArray = (a as Array);
      Array bArray = (b as Array);

      if (aArray.Length != bArray.Length) {
        return false;
      }

      for (int i = 0, s = aArray.Length; i < s; i++) {
        if (!deepEquals(aArray.GetValue(i), bArray.GetValue(i))) {
          return false;
        }
      }

      return true;
    }
    else if (type.IsClass) {
      FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
      foreach (FieldInfo field in fields) {
        if (!deepEquals(field.GetValue(a), field.GetValue(b))) {
          return false;
        }
      }
      return true;
    }
    else
      throw new ArgumentException("Unknown type");
  }

  // -------------------------------------------------------------------------
  public static bool deepEquals<T>(this T a, T b)
    => deepEquals((object) a, (object) b);
}

} // End of namespace th.SimIO
