/* ----------------------------------------------------------------------- *

    * InputDeviceMouse.cs

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

using static th.simio.ElementIdentifier;
using static th.simio.ElementIdentifier.ElementType;

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Mouse
{
  public readonly static ElementIdentifier xPosition = new ElementIdentifier(typeof(AbsoluteAxis), "x position");
  public readonly static ElementIdentifier yPosition = new ElementIdentifier(typeof(AbsoluteAxis), "y position");

  public readonly static ElementIdentifier xAxis = new ElementIdentifier(typeof(RelativeAxis), "x axis");
  public readonly static ElementIdentifier yAxis = new ElementIdentifier(typeof(RelativeAxis), "y axis");

  public readonly static ElementIdentifier wheelX = new ElementIdentifier(typeof(RelativeAxis), "wheel X");
  public readonly static ElementIdentifier wheelY = new ElementIdentifier(typeof(RelativeAxis), "wheel Y");

  public readonly static ElementIdentifier leftButton = new ElementIdentifier(typeof(Button), "left button");
  public readonly static ElementIdentifier rightButton = new ElementIdentifier(typeof(Button), "right button");
  public readonly static ElementIdentifier middleButton = new ElementIdentifier(typeof(Button), "middle button");

  public readonly static ElementIdentifier forwardButton = new ElementIdentifier(typeof(Button), "forward button");
  public readonly static ElementIdentifier backButton = new ElementIdentifier(typeof(Button), "back button");
}

} // End of namespace th.simio
