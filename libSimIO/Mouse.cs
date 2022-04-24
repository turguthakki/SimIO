/* ----------------------------------------------------------------------- *

    * Mouse.cs

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

using static th.SimIO.ElementIdentifier;
using static th.SimIO.ElementIdentifier.ElementType;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Element identifiers for mouses.
/// </summary>
public static class Mouse
{
  /// <summary>
  /// Identifies an axis that reports horizontal position of mouse cursor.
  /// </summary>
  public readonly static ElementIdentifier xPosition = new ElementIdentifier(typeof(AbsoluteAxis), "x position");

  /// <summary>
  /// Identifies an axis that reports vertical position of mouse cursor.
  /// </summary>
  public readonly static ElementIdentifier yPosition = new ElementIdentifier(typeof(AbsoluteAxis), "y position");

  /// <summary>
  /// Identifies an axis that reports horizontal mouse movement.
  /// </summary>
  public readonly static ElementIdentifier xAxis = new ElementIdentifier(typeof(RelativeAxis), "x axis");
  /// <summary>
  /// Identifies an axis that reports vertical mouse movement.
  /// </summary>
  public readonly static ElementIdentifier yAxis = new ElementIdentifier(typeof(RelativeAxis), "y axis");

  /// <summary>
  /// Identifies an axis that reports mouse wheel movement
  /// </summary>
  public readonly static ElementIdentifier wheelX = new ElementIdentifier(typeof(RelativeAxis), "wheel X");
  /// <summary>
  /// Identifies an axis that reports horizontal mouse wheel movement
  /// </summary>
  public readonly static ElementIdentifier wheelY = new ElementIdentifier(typeof(RelativeAxis), "wheel Y");

  /// <summary>
  /// Identifies left mouse button
  /// </summary>
  public readonly static ElementIdentifier leftButton = new ElementIdentifier(typeof(Button), "left button");

  /// <summary>
  /// Identifies right mouse button
  /// </summary>
  public readonly static ElementIdentifier rightButton = new ElementIdentifier(typeof(Button), "right button");
  /// <summary>
  /// Identifies middle mouse button
  /// </summary>
  public readonly static ElementIdentifier middleButton = new ElementIdentifier(typeof(Button), "middle button");

  /// <summary>
  /// Identifies "forward" button on the mouse
  /// </summary>
  public readonly static ElementIdentifier forwardButton = new ElementIdentifier(typeof(Button), "forward button");
  /// <summary>
  /// Identifies "back" button on the mouse
  /// </summary>
  public readonly static ElementIdentifier backButton = new ElementIdentifier(typeof(Button), "back button");

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  /// <summary>
  /// Mouse wrapper.
  /// Defines quickly accessible member variables to known mouse elements.
  /// <warning>Elements may be null when they are not present on input device.</warning>
  /// </summary>
  public class InputDeviceWrapper : InputDevice.Wrapper
  {
    /// <summary> Horitonal mouse position on screen </summary>
    public InputDevice.Element xPosition {get; protected set;} = null;
    /// <summary> Vertical mouse position on screen </summary>
    public InputDevice.Element yPosition {get; protected set;} = null;
    /// <summary> Horizontal mouse movement. </summary>
    public InputDevice.Element xAxis {get; protected set;} = null;
    /// <summary> Vertical mouse movement </summary>
    public InputDevice.Element yAxis {get; protected set;} = null;
    /// <summary> Mouse wheel movement </summary>
    public InputDevice.Element wheelX {get; protected set;} = null;
    /// <summary> Horizontal mouse wheel movement </summary>
    public InputDevice.Element wheelY {get; protected set;} = null;
    /// <summary> Left mouse button </summary>
    public InputDevice.Element leftButton {get; protected set;} = null;
    /// <summary> Right mouse button </summary>
    public InputDevice.Element rightButton {get; protected set;} = null;
    /// <summary> Middle mouse button </summary>
    public InputDevice.Element middleButton {get; protected set;} = null;
    /// <summary> Forward button </summary>
    public InputDevice.Element forwardButton {get; protected set;} = null;
    /// <summary> Back button </summary>
    public InputDevice.Element backButton {get; protected set;} = null;

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using the first mouse device
    /// </summary>
    public InputDeviceWrapper() : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Mouse>()))
    {
    }

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using the first device complying with given criteria.
    /// <para>
    /// Essentially, same as doing : <c> new Mouse.InputDeviceWrapper(SimIO.inputDevices.First(d => some criteria)); </c>
    /// </para>
    /// </summary>
    public InputDeviceWrapper(Func<InputDevice, bool> predicate) : this(SimIO.inputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Mouse>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using given device
    /// </summary>
    public InputDeviceWrapper(InputDevice device) : base(device)
    {
      xPosition = device[Mouse.xPosition];
      yPosition = device[Mouse.yPosition];
      xAxis = device[Mouse.xAxis];
      yAxis = device[Mouse.yAxis];
      wheelX = device[Mouse.wheelX];
      wheelY = device[Mouse.wheelY];
      leftButton = device[Mouse.leftButton];
      rightButton = device[Mouse.rightButton];
      middleButton = device[Mouse.middleButton];
      forwardButton = device[Mouse.forwardButton];
      backButton = device[Mouse.backButton];
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class OutputDeviceWrapper : OutputDevice.Wrapper
  {
    /// <summary> Horitonal mouse position on screen </summary>
    public OutputDevice.Element xPosition {get; protected set;} = null;
    /// <summary> Vertical mouse position on screen </summary>
    public OutputDevice.Element yPosition {get; protected set;} = null;
    /// <summary> Horizontal mouse movement. </summary>
    public OutputDevice.Element xAxis {get; protected set;} = null;
    /// <summary> Vertical mouse movement </summary>
    public OutputDevice.Element yAxis {get; protected set;} = null;
    /// <summary> Mouse wheel movement </summary>
    public OutputDevice.Element wheelX {get; protected set;} = null;
    /// <summary> Horizontal mouse wheel movement </summary>
    public OutputDevice.Element wheelY {get; protected set;} = null;
    /// <summary> Left mouse button </summary>
    public OutputDevice.Element leftButton {get; protected set;} = null;
    /// <summary> Right mouse button </summary>
    public OutputDevice.Element rightButton {get; protected set;} = null;
    /// <summary> Middle mouse button </summary>
    public OutputDevice.Element middleButton {get; protected set;} = null;
    /// <summary> Forward button </summary>
    public OutputDevice.Element forwardButton {get; protected set;} = null;
    /// <summary> Back button </summary>
    public OutputDevice.Element backButton {get; protected set;} = null;

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using the first mouse device
    /// </summary>
    public OutputDeviceWrapper() : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Mouse>()))
    {
    }

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using the first device complying with given criteria.
    /// <para>
    /// Same as doing : <c> new Mouse.OutputDeviceWrapper(SimIO.outputDevices.First(d => some criteria)); </c>
    /// </para>
    /// </summary>
    public OutputDeviceWrapper(Func<OutputDevice, bool> predicate) : this(SimIO.outputDevices.First(d => d.deviceType.isKindOf<InputDevice.DeviceType.Mouse>() && predicate(d)))
    {
    }

    // -----------------------------------------------------------------------
    /// <summary>
    /// Initializes the wrapper using given device
    /// </summary>
    public OutputDeviceWrapper(OutputDevice device) : base(device)
    {
      xPosition = device[Mouse.xPosition];
      yPosition = device[Mouse.yPosition];
      xAxis = device[Mouse.xAxis];
      yAxis = device[Mouse.yAxis];
      wheelX = device[Mouse.wheelX];
      wheelY = device[Mouse.wheelY];
      leftButton = device[Mouse.leftButton];
      rightButton = device[Mouse.rightButton];
      middleButton = device[Mouse.middleButton];
      forwardButton = device[Mouse.forwardButton];
      backButton = device[Mouse.backButton];
    }
  }

}

} // End of namespace th.simio
