/* ----------------------------------------------------------------------- *

    * RawInputHelpers.cs

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

namespace th.SimIO.Helpers {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Helpers
{
  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if Element's id matches identifier i
  /// </summary>
  public static bool isKindOf(this InputDevice.Element e, ElementIdentifier i) => e.identifier == i;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if Element's id matches any of identifiers ids
  /// </summary>
  public static bool isKindOf(this InputDevice.Element e, params ElementIdentifier[] ids) => ids.Any(id => e.identifier == id);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if Element's id matches identifier i
  /// </summary>
  public static bool isKindOf(this OutputDevice.Element e, ElementIdentifier i) => e.id == i;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if Element's id matches any of identifiers ids
  /// </summary>
  public static bool isKindOf(this OutputDevice.Element e, params ElementIdentifier[] ids) => ids.Any(id => e.id == id);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns true if Element e is part of an HID device and usagePage and usage matches
  /// </summary>
  public static bool isKindOf(this InputDevice.Element e, HidUsage.UsagePage usagePage, HidUsage.Usage usage)
  {
    HidIdentifier i = e.identifier as HidIdentifier;
    return i != null && i.usagePage == usagePage && i.usage == usage;
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns true if Element e is part of an HID device, it's elementType (th.simio.ElementIdentifier.ElementType), usagePage and usage matches
  /// </summary>
  public static bool isKindOf(this InputDevice.Element e, Type elementType, HidUsage.UsagePage usagePage, HidUsage.Usage usage)
  {
    HidIdentifier i = e.identifier as HidIdentifier;
    return i != null && elementType.isKindOf<ElementIdentifier.ElementType>() && i.isKindOf(elementType) && i.usagePage == usagePage && i.usage == usage;
  }

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element
  /// </summary>
  public static InputDevice.Element firstOf(this IEnumerable<InputDevice.Element> elements, ElementIdentifier i) => elements.FirstOrDefault(e => e.isKindOf(i));

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element
  /// </summary>
  public static OutputDevice.Element firstOf(this IEnumerable<OutputDevice.Element> elements, ElementIdentifier i) => elements.FirstOrDefault(e => e.isKindOf(i));

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element with usagePage and usage
  /// </summary>
  public static InputDevice.Element firstOf(this IEnumerable<InputDevice.Element> elements, HidUsage.UsagePage usagePage, HidUsage.Usage usage) => elements.FirstOrDefault(e => e.isKindOf(usagePage, usage));

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element with elementType, usagePage and usage
  /// </summary>
  public static InputDevice.Element firstOf(this IEnumerable<InputDevice.Element> elements, Type elementType, HidUsage.UsagePage usagePage, HidUsage.Usage usage) => elements.FirstOrDefault(e => e.isKindOf(elementType, usagePage, usage));

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element
  /// </summary>
  public static InputDevice.Element firstOf(this InputDevice device, ElementIdentifier i) => device.elements.firstOf(i);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element
  /// </summary>
  public static OutputDevice.Element firstOf(this OutputDevice device, ElementIdentifier i) => device.elements.firstOf(i);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element with usagePage and usage
  /// </summary>
  public static InputDevice.Element firstOf(this InputDevice device, HidUsage.UsagePage usagePage, HidUsage.Usage usage) => device.elements.firstOf(usagePage, usage);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns first matcing element with elementType, usagePage and usage
  /// </summary>
  public static InputDevice.Element firstOf(this InputDevice device, Type elementType, HidUsage.UsagePage usagePage, HidUsage.Usage usage) => device.elements.firstOf(elementType, usagePage, usage);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns element's position normalized between 0 and 1
  /// </summary>
  public static float normalizedPosition(this InputDevice.Element e) => (e.position - e.minimumValue) / (e.maximumValue - e.minimumValue);

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns element's position normalized between -1 and 1
  /// </summary>
  public static float bidiNormalizedPosition(this InputDevice.Element e) => e.normalizedPosition() * 2.0f - 1.0f;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if element is currently down
  /// </summary>
  public static bool isDown(this InputDevice.Element e) => Math.Abs(e.isBidirectional ? e.bidiNormalizedPosition() : e.normalizedPosition()) > 0.5f;

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if element's id is matching with id and currently down.
  /// <example>
  /// <code>element.isDown(Keyboard.escape)</code>
  /// </example>
  /// </summary>
  public static bool isDown(this InputDevice.Element e, ElementIdentifier id) => e.isKindOf(id) && e.isDown();

  // -------------------------------------------------------------------------
  /// <summary>
  /// Returns if element's id is matching with any of given id's and currently down.
  /// <example>
  /// <code>element.isDown(Keyboard.escape, HID.button1)</code>
  /// </example>
  /// </summary>
  public static bool isDown(this InputDevice.Element e, params ElementIdentifier[] ids) => e.isKindOf(ids) && e.isDown();
}

} // End of namespace th.simio.helpers
