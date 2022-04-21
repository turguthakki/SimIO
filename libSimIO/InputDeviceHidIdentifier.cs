/* ----------------------------------------------------------------------- *

    * InputDeviceHidIdentifier.cs

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

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Element identifier for HID compatible devices
/// Please see <a href="https://www.usb.org/sites/default/files/documents/hut1_12v2.pdf">USB HID Usage tables</a> for detailed documentation
/// </summary>
public class HidIdentifier : ElementIdentifier
{
  /// <summary>
  /// Usage page of the element
  /// </summary>
  public HidUsage.UsagePage usagePage {get ;private set;}
  /// <summary>
  /// Usage of the element
  /// </summary>
  public HidUsage.Usage usage {get; private set;}

  // -----------------------------------------------------------------------
  /// <summary>
  /// Constructor
  /// </summary>
  /// <param name="type">Element type. Must be derived from ElementIdentifier.ElementType</param>
  /// <param name="usagePage">HUD usage page</param>
  /// <param name="usage">Hid usage</param>
  /// <param name="name">Debug string</param>
  /// <returns></returns>
  public HidIdentifier(Type type, HidUsage.UsagePage usagePage, HidUsage.Usage usage, string name = "") : base(type, name)
  {
    this.usagePage = usagePage;
    this.usage = usage;
  }

  // -----------------------------------------------------------------------
  public override int GetHashCode()
  {
    return ((int) usagePage << 16 | (int) usage);
  }

  // -----------------------------------------------------------------------
  public override bool Equals(object rh)
  {
    if (this is null && rh is null)
      return true;
    else if (this is null != rh is null)
      return false;

    if (rh.GetType() == typeof(Int32))
      return GetHashCode() == (int) rh;
    else if (rh.GetType() == typeof(UInt32))
      return GetHashCode() == (int) rh;

    return Equals(rh as HidIdentifier);
  }

  // -----------------------------------------------------------------------
  public override bool Equals(ElementIdentifier rh)
  {
    if (this is null && rh is null)
      return true;
    else if (this is null != rh is null)
      return false;

    HidIdentifier ki = rh as HidIdentifier;

    if (ki is null)
      return false;

    return type == ki.type && usagePage == ki.usagePage && usage == ki.usage;
  }
}

} // End of namespace th.simio
