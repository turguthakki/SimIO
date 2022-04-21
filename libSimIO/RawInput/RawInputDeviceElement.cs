/* ----------------------------------------------------------------------- *

    * RawInputDeviceElement.cs

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
public partial class RawInputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public class RawInputDeviceElement : InputDevice.Element
  {
    unsafe internal delegate void HIDValueHandler(RAWINPUT *input, RawInputDeviceElement element);
    public InputDevice device {get; private set;}
    public ElementIdentifier identifier {get; private set;}

    public bool isCyclic {get; private set;}
    public bool isRelative {get; private set;}
    public bool isAbsolute {get; private set;}

    public float minimumValue {get; private set;}
    public float maximumValue {get; private set;}

    public bool isValid {get; private set;} = true;
    public float value {get; private set;}
    public float position {get; private set;}
    public float motion {get; private set;}

    public event InputNotification onInput = delegate{};

    internal HidIdentifier hidIdentifier => identifier as HidIdentifier;
    internal bool tmpValue;
    internal HIDValueHandler valueHandler;

    // -------------------------------------------------------------------------
    internal RawInputDeviceElement(RawInputDevice device, ElementIdentifier id, bool isAbsolute = true, float minimumValue = 0.0f, float maximumValue = 1.0f, bool isCyclic = false)
    {
      this.device = device;
      this.identifier = id;
      this.isAbsolute = isAbsolute;
      this.isRelative = !isAbsolute;
      this.minimumValue = minimumValue;
      this.maximumValue = maximumValue;
      this.isCyclic = isCyclic;
    }

    // -----------------------------------------------------------------------
    internal void setAbsoluteData(float position, bool isValid = true)
    {
      if (position != this.position || this.isValid != isValid) {
        this.isValid = isValid;
        this.motion = position - this.position;
        this.value = this.position = position;
        onInput(device, this);
      }
    }

    // -----------------------------------------------------------------------
    internal void setRelativeData(float motion, bool isValid = true)
    {
      if (this.motion != motion || this.isValid != isValid) {
        this.isValid = isValid;
        this.value = this.motion = motion;
        this.position = 0;
        onInput(device, this);
      }
    }
  }
}

} // End of namespace th.simio
