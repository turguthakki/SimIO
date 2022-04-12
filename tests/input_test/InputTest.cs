﻿/* ----------------------------------------------------------------------- *

    * InputTest.cs

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
public class InputTest
{
  // -------------------------------------------------------------------------
  static void Main()
  {
    SimIO.inputDevicesChanged += (device) => {
      Console.WriteLine(device.deviceType.Name + " device " + device.deviceIdentifier + " " + (device.isAttached ? "attached" : "detached"));
    };

    SimIO.onInput += (device, element) => {
      Console.WriteLine(device.deviceType.Name + " " + device.deviceIdentifier + " " + element.id.type.Name + " " + element.id.name + " " + element.value);
    };

    bool running = true;
    while(running) {
      SimIO.update();

      Thread.Sleep(16);
    }

    Console.WriteLine("Ok");
  }
}

} // End of namespace th