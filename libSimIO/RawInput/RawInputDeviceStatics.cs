/* ----------------------------------------------------------------------- *

    * RawInputDeviceStatics.cs

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
using static System.Runtime.InteropServices.Marshal;

namespace th.SimIO {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public partial class RawInputDevice
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public unsafe class DataRelay
  {
    RawInputDevice device;
    RAWINPUT *data;

    // -----------------------------------------------------------------------
    public DataRelay(RawInputDevice device)
    {
      this.device = device;
    }

    // -----------------------------------------------------------------------
    public void setData(RAWINPUT *data)
    {
      this.data = data;
    }

    // -----------------------------------------------------------------------
    public void update()
    {
      foreach(var e in device.elements.Where(e => e.isAbsolute).Select(e => e as RawInputDeviceElement)) {
        e.clearMotion();
      }
      if (data != null) {
        device.update(data);
        FreeHGlobal((IntPtr) data);
        data = null;
      }
      else {
        device.updateWithNoData();
      }
    }
  }

  // -------------------------------------------------------------------------
  static IntPtr hInstance = GetModuleHandle(null);
  static WNDCLASSEX wind_class = new WNDCLASSEX();
  static IntPtr hWnd = IntPtr.Zero;
  static MSG msg = new MSG();
  static List<RawInputDevice> rawInputDevices = new List<RawInputDevice>();
  static Dictionary<IntPtr, DataRelay> updateMap = new Dictionary<IntPtr, DataRelay>();
  static unsafe Queue<IntPtr> dataQueue = new Queue<IntPtr>();
  static WNDPROC wndProcDelegate;
  static IntPtr wndProcDelegatePtr;

  // -------------------------------------------------------------------------
  internal static void init()
  {
    wind_class.cbSize = Marshal.SizeOf(typeof(WNDCLASSEX));
    wind_class.lpfnWndProc = wndProcDelegatePtr = Marshal.GetFunctionPointerForDelegate(wndProcDelegate = (WNDPROC) WndProc);
    wind_class.hInstance = hInstance;
    wind_class.lpszClassName = "simio_window";
    RegisterClassEx(ref wind_class);
    hWnd = CreateWindowEx(0, "simio_window", null, 0, 0, 0, 0, 0, nullptr, nullptr, hInstance, nullptr);

    RAWINPUTDEVICE[] __rawinput_rid = new RAWINPUTDEVICE[] {
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x01, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x02, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x04, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x05, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x06, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
      new RAWINPUTDEVICE() {usUsagePage = 0x01, usUsage = 0x07, dwFlags = RIDEV_DEVNOTIFY | RIDEV_INPUTSINK, hwndTarget = hWnd},
    };

    RegisterRawInputDevices(__rawinput_rid, __rawinput_rid.Length, Marshal.SizeOf(typeof(RAWINPUTDEVICE)));
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  sealed class StaticDtor
  {
    // -----------------------------------------------------------------------
    ~StaticDtor()
    {
      RegisterRawInputDevices(null, 0, Marshal.SizeOf(typeof(RAWINPUTDEVICE)));
      DestroyWindow(hWnd);
      UnregisterClass("simio_window", hInstance);
    }
  }
  static readonly StaticDtor staticDtor = new StaticDtor();

  // -------------------------------------------------------------------------
  static string getDevicePath(IntPtr handle)
  {
    string rv = "";
    uint sz = 0;
    GetRawInputDeviceInfo(handle, RIDI_DEVICENAME, IntPtr.Zero, ref sz);
    IntPtr ptr = Marshal.AllocHGlobal(sizeof(char) * (int) (sz + 1));
    GetRawInputDeviceInfo(handle, RIDI_DEVICENAME, ptr, ref sz);
    rv = Marshal.PtrToStringUni(ptr)!;
    Marshal.FreeHGlobal(ptr);
    return rv;
  }

  // -------------------------------------------------------------------------
  static internal RID_DEVICE_INFO getDeviceInfo(IntPtr handle)
  {
    RID_DEVICE_INFO rv;
    IntPtr deviceInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf<RID_DEVICE_INFO>());
    uint deviceInfoSize = (uint) Marshal.SizeOf<RID_DEVICE_INFO>();
    GetRawInputDeviceInfo(handle, RIDI_DEVICEINFO, deviceInfoPtr, ref deviceInfoSize);
    rv = Marshal.PtrToStructure<RID_DEVICE_INFO>(deviceInfoPtr);
    Marshal.FreeHGlobal(deviceInfoPtr);
    return rv;
  }

  // -------------------------------------------------------------------------
  static Dictionary<string, RAWINPUTDEVICELIST> enumerateAttachedDevices()
  {
    uint deviceCount = 0;
    RAWINPUTDEVICELIST[] deviceList = null;

    GetRawInputDeviceList(null, ref deviceCount, (uint) Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));
    deviceList = new RAWINPUTDEVICELIST[deviceCount];
    GetRawInputDeviceList(deviceList, ref deviceCount, (uint) Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));

    Dictionary<string, RAWINPUTDEVICELIST> rv = new Dictionary<string, RAWINPUTDEVICELIST>();

    foreach (var dev in deviceList) {
      string identifier = "rawinput:" + getDevicePath(dev.hDevice);
      rv[identifier] = dev;
    }

    return rv;
  }


  // -------------------------------------------------------------------------
  internal static void enumerateDevices()
  {
    Dictionary<string, RAWINPUTDEVICELIST> attachedDevices = enumerateAttachedDevices();

    foreach (var device in rawInputDevices) {
      if (!attachedDevices.ContainsKey(device.deviceIdentifier))
        device.isAttached = false;
      else
        device.isAttached = true;
    }

    foreach(var device in attachedDevices) {
      if (!rawInputDevices.Any(d => d.deviceIdentifier == device.Key)) {
        RawInputDevice newRawInputDevice = null;

        try {
          IntPtr deviceHandle = device.Value.hDevice;
          string devicePath = device.Key;
          RID_DEVICE_INFO deviceInfo = getDeviceInfo(deviceHandle);

          switch(device.Value.dwType) {
            case RIM_TYPEMOUSE : newRawInputDevice = new RawInputMouse(deviceHandle, devicePath, deviceInfo); break;
            case RIM_TYPEKEYBOARD : newRawInputDevice = new RawInputKeyboard(deviceHandle, devicePath, deviceInfo); break;
            case RIM_TYPEHID :
              switch((HidUsage.UsagePage) deviceInfo.hid.usUsagePage) {
                case HidUsage.UsagePage.GenericDesktop :
                case HidUsage.UsagePage.SimulationControls :
                case HidUsage.UsagePage.VrControls :
                case HidUsage.UsagePage.SportControls :
                case HidUsage.UsagePage.GameControls :
                case HidUsage.UsagePage.GenericDeviceControls :
                case HidUsage.UsagePage.Keyboard :
                case HidUsage.UsagePage.Led :
                case HidUsage.UsagePage.Button :
                case HidUsage.UsagePage.Ordinal :
                case HidUsage.UsagePage.Telephony :
                case HidUsage.UsagePage.Consumer :
                case HidUsage.UsagePage.Digitizers :
                case HidUsage.UsagePage.Unicode :
                case HidUsage.UsagePage.AlphanumericDisplay :
                case HidUsage.UsagePage.MedicalInstrument :
                  break;
                default : {
                } continue;
              }

              switch((HidUsage.Usage) deviceInfo.hid.usUsage) {
                case HidUsage.Usage.Pointer :
                case HidUsage.Usage.Mouse    : newRawInputDevice = new RawInputMouse(deviceHandle, devicePath, deviceInfo);  break;

                case HidUsage.Usage.Keyboard :
                case HidUsage.Usage.Keypad   : newRawInputDevice = new RawInputKeyboard(deviceHandle, devicePath, deviceInfo); break;

                case HidUsage.Usage.Joystick :
                case HidUsage.Usage.GamePad : newRawInputDevice = new RawInputHID(deviceHandle, devicePath, deviceInfo); break;
              }
              break;
            default : continue;
          }
        }
        catch(SystemException) {
          continue;
        }

        if (newRawInputDevice is null)
          continue;

        lock(rawInputDevices) {
          rawInputDevices.Add(newRawInputDevice);
          updateMap.Add(newRawInputDevice.deviceHandle, new DataRelay(newRawInputDevice));
          registerInputDevice(newRawInputDevice);
        }
      }
    }
  }

  // -------------------------------------------------------------------------
  unsafe static IntPtr WndProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
  {
    switch(uMsg) {
      case WM_INPUT_DEVICE_CHANGE : {
        enumerateDevices();
      } break;
      case WM_INPUT : {
        uint size = 1;
        GetRawInputData(lParam, RID_INPUT, nullptr, ref size, (uint) SizeOf<RAWINPUTHEADER>());
        IntPtr data = AllocHGlobal((int) size);
        GetRawInputData(lParam, RID_INPUT, data, ref size, (uint) SizeOf<RAWINPUTHEADER>());
        lock(dataQueue)
          dataQueue.Enqueue(data);
      } break;
    }

    return DefWindowProc(hWnd, uMsg, wParam, lParam);
  }

  // -------------------------------------------------------------------------
  unsafe static internal void update()
  {
    while(PeekMessage(out msg, hWnd, 0, 0, PM_REMOVE)) {
      TranslateMessage(ref msg);
      DispatchMessage(ref msg);
    }

    while(true) {
      RAWINPUT *data = null;
      lock(dataQueue) {
        if (dataQueue.Count > 0) {
          data = (RAWINPUT *) dataQueue.Dequeue();
        }
        else
          break;
        DataRelay relay;
        if (updateMap.TryGetValue(data->header.hDevice, out relay)) {
          relay.setData(data);
        }
      }
    }

    foreach(var r in updateMap.Values) {
      r.update();
    }
  }
}

} // End of namespace th.simio
