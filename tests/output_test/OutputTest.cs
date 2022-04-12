﻿/* ----------------------------------------------------------------------- *

    * OutputTest.cs

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
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Runtime.InteropServices;
global using th.simio;
global using static th.simio.User32;
global using static th.simio.Kernel32;

namespace th {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class OutputTest
{
  // -------------------------------------------------------------------------
  static void Main()
  {
    // InputDevice joystick = SimIO.inputDevices.First(d => d is RawInputHID && (d as RawInputHID).productString == "Saitek X52 Flight Control System");
    InputDevice joystick = SimIO.inputDevices.First();
    OutputDevice vJoy = SimIO.outputDevices.First(d => d is vJoyDevice);

    foreach(var i in joystick.elements) {
      var id = i.id as HidIdentifier;
      var outE = vJoy.elements.FirstOrDefault(e => (e.id as HidIdentifier).usagePage == id.usagePage && (e.id as HidIdentifier).usage == id.usage);

      if (outE is not null) {
        i.onInput += (d, e) => {
          outE.value = i.value * outE.maximumValue;
        };
      }
    }


    bool running = true;
    while(running) {
      SimIO.update();
      Thread.Sleep(16);
    }

    Console.WriteLine("Ok");
  }
}

} // End of namespace th