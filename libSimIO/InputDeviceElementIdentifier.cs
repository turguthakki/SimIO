/* ----------------------------------------------------------------------- *

    * InputDeviceElementIdentifier.cs

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
public class ElementIdentifier : IEquatable<ElementIdentifier>
{
  // -------------------------------------------------------------------------
  public interface ElementType
  {
    public interface Axis : ElementType {}
    public interface RelativeAxis : Axis {}
    public interface AbsoluteAxis : Axis {}
    public interface POVHat : AbsoluteAxis {}
    public interface Button : ElementType {}
    public interface Key : Button {}
  };

  public string name {get; private set;}
  public Type type {get; private set;}

  // -------------------------------------------------------------------------
  public ElementIdentifier(Type type, string name)
  {
    if (type is ElementType) {
      throw new System.NotSupportedException("Element type must be kind of th.ElementIdentifier.ElementType");
    }
    this.type = type;
    this.name = name;
  }

  // -------------------------------------------------------------------------
  public override int GetHashCode()
  {
    return base.GetHashCode();
  }

  // -------------------------------------------------------------------------
  public override bool Equals(object o)
  {
    return Equals(o as ElementIdentifier);
  }

  // -------------------------------------------------------------------------
  public virtual bool Equals(ElementIdentifier rh)
  {
    return (this is null == rh is null) && (this is not null && rh is not null ? GetType() == rh.GetType() && type == rh.type && System.Object.ReferenceEquals(this, rh) : false);
  }
}

} // End of namespace th.simio
