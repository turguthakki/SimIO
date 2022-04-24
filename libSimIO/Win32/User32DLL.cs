/* ----------------------------------------------------------------------- *

    * User32DLL.cs

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
/// <summary>
/// User32.dll
/// </summary>
public static class User32DLL
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-wndproc
  public delegate IntPtr WNDPROC(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-wndclassexw
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public unsafe struct WNDCLASSEX
  {
    [MarshalAs(UnmanagedType.U4)]
    public int cbSize = Marshal.SizeOf(typeof(WNDCLASSEX));
    [MarshalAs(UnmanagedType.U4)]
    public int style = 0;
    public IntPtr lpfnWndProc = IntPtr.Zero;
    public int cbClsExtra = 0;
    public int cbWndExtra = 0;
    public IntPtr hInstance = IntPtr.Zero;
    public IntPtr hIcon = IntPtr.Zero;
    public IntPtr hCursor = IntPtr.Zero;
    public IntPtr hbrBackground = IntPtr.Zero;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string lpszMenuName = null;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string lpszClassName = null;
    public IntPtr hIconSm = IntPtr.Zero;

    // -----------------------------------------------------------------------
    public WNDCLASSEX()
    {
    }
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msg
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct MSG
  {
    public IntPtr hwnd;
    public uint message;
    public IntPtr wParam;
    public IntPtr lParam;
    public UInt32 time;
    public IntPtr pt;
    public UInt32 lPrivate;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RAWINPUTDEVICE
  {
    public UInt16 usUsagePage;
    public UInt16 usUsage;
    public UInt32 dwFlags;
    public IntPtr hwndTarget;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevicelist
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RAWINPUTDEVICELIST
  {
    public IntPtr hDevice;
    public UInt32 dwType;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info_mouse
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RID_DEVICE_INFO_MOUSE
  {
    public UInt32 dwId;
    public UInt32 dwNumberOfButtons;
    public UInt32 dwSampleRate;
    [MarshalAs(UnmanagedType.Bool)] public bool fHasHorizontalWheel;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info_keyboard
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RID_DEVICE_INFO_KEYBOARD
  {
    public UInt32 dwType;
    public UInt32 dwSubType;
    public UInt32 dwKeyboardMode;
    public UInt32 dwNumberOfFunctionKeys;
    public UInt32 dwNumberOfIndicators;
    public UInt32 dwNumberOfKeysTotal;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info_hid
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RID_DEVICE_INFO_HID
  {
    public UInt32 dwVendorId;
    public UInt32 dwProductId;
    public UInt32 dwVersionNumber;
    public UInt16 usUsagePage;
    public UInt16 usUsage;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info
  [StructLayout(LayoutKind.Explicit)]
  public unsafe struct RID_DEVICE_INFO
  {
    [FieldOffset(0)] public UInt32 cbSize;
    [FieldOffset(4)] public UInt32 dwType;
    [FieldOffset(8)] public RID_DEVICE_INFO_MOUSE    mouse;
    [FieldOffset(8)] public RID_DEVICE_INFO_KEYBOARD keyboard;
    [FieldOffset(8)] public RID_DEVICE_INFO_HID      hid;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputheader
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RAWINPUTHEADER
  {
    public UInt32 dwType;
    public UInt32 dwSize;
    public IntPtr hDevice;
    public IntPtr wParam;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawmouse
  [StructLayout(LayoutKind.Explicit)]
  public unsafe struct RAWMOUSE
  {
    [FieldOffset(0)] public UInt16 usFlags;
    [FieldOffset(4)] public UInt32 ulButtons;
    [FieldOffset(4)] public UInt16 usButtonFlags;
    [FieldOffset(6)] public UInt32 usButtonData;
    [FieldOffset(8)] public UInt32  ulRawButtons;
    [FieldOffset(12)] public Int32 lLastX;
    [FieldOffset(16)] public Int32 lLastY;
    [FieldOffset(20)] public UInt32 ulExtraInformation;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawkeyboard
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RAWKEYBOARD
  {
    public ushort MakeCode;
    public ushort Flags;
    public ushort Reserved;
    public ushort VKey;
    public uint Message;
    public ulong ExtraInformation;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawhid
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct RAWHID
  {
    public UInt32 dwSizeHid;
    public UInt32 dwCount;
    public fixed byte bRawData[1];
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinput
  [StructLayout(LayoutKind.Explicit)]
  public unsafe struct RAWINPUT
  {
    [FieldOffset(0)] public RAWINPUTHEADER header;
    [FieldOffset(24)] public RAWMOUSE mouse;
    [FieldOffset(24)] public RAWKEYBOARD keyboard;
    [FieldOffset(24)] public RAWHID hid;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput
  [StructLayout(LayoutKind.Sequential)]
  public struct KEYBDINPUT
  {
    public UInt16 wVk = 0;
    public UInt16 wScan = 0;
    public UInt32 dwFlags = 0;
    public UInt32 time = 0;
    public IntPtr dwExtraInfo = IntPtr.Zero;

    // -----------------------------------------------------------------------
    public KEYBDINPUT()
    {
    }
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
  [StructLayout(LayoutKind.Sequential)]
  public struct MOUSEINPUT
  {
    public Int32 dx = 0;
    public Int32 dy = 0;
    public UInt32 mouseData = 0;
    public UInt32 dwFlags = 0;
    public UInt32 time = 0;
    public IntPtr dwExtraInfo = IntPtr.Zero;

    // -----------------------------------------------------------------------
    public MOUSEINPUT()
    {
    }
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input
  [StructLayout(LayoutKind.Explicit)]
  public struct INPUT
  {
    [FieldOffset(0)] public UInt32 type;
    [FieldOffset(8)] public KEYBDINPUT ki;
    [FieldOffset(8)] public MOUSEINPUT mi;
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/previous-versions/dd162805(v=vs.85)
  [StructLayout(LayoutKind.Sequential)]
  public struct POINT
  {
    public Int32 x;
    public Int32 y;
  };

  // -------------------------------------------------------------------------
  public static readonly IntPtr nullptr = IntPtr.Zero;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
  public const UInt16 RIDEV_REMOVE = 0x00000001;
  public const UInt16 RIDEV_EXCLUDE = 0x00000010;
  public const UInt16 RIDEV_PAGEONLY = 0x00000020;
  public const UInt16 RIDEV_NOLEGACY = 0x00000030;
  public const UInt16 RIDEV_INPUTSINK = 0x00000100;
  public const UInt16 RIDEV_CAPTUREMOUSE = 0x00000200;
  public const UInt16 RIDEV_NOHOTKEYS = 0x00000200;
  public const UInt16 RIDEV_APPKEYS = 0x00000400;
  public const UInt16 RIDEV_EXINPUTSINK = 0x00001000;
  public const UInt16 RIDEV_DEVNOTIFY = 0x00002000;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-peekmessagew
  public const uint PM_NOREMOVE = 0x0000;
  public const uint PM_REMOVE = 0x0001;
  public const uint PM_NOYIELD = 0x0002;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevicelist
  public const UInt32 RIM_TYPEHID = 2;
  public const UInt32 RIM_TYPEKEYBOARD = 1;
  public const UInt32 RIM_TYPEMOUSE = 0;

  public const uint RIDI_PREPARSEDDATA = 0x20000005;
  public const uint RIDI_DEVICENAME = 0x20000007;
  public const uint RIDI_DEVICEINFO = 0x2000000b;

  // https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-input-device-change
  public const uint WM_INPUT_DEVICE_CHANGE = 0x00FE;

  // https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-input
  public const uint WM_INPUT = 0x00FF;

  // https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-quit
  public const uint WM_QUIT = 0x0012;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdata
  public const uint RID_HEADER = 0x10000005;
  public const uint RID_INPUT = 0x10000003;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawmouse
  public const ushort MOUSE_MOVE_RELATIVE = 0x00;
  public const ushort MOUSE_MOVE_ABSOLUTE = 0x01;
  public const ushort MOUSE_VIRTUAL_DESKTOP = 0x02;
  public const ushort MOUSE_ATTRIBUTES_CHANGED = 0x04;
  public const ushort MOUSE_MOVE_NOCOALESCE = 0x04;

  public const ushort RI_MOUSE_BUTTON_1_DOWN = 0x0001;
  public const ushort RI_MOUSE_LEFT_BUTTON_DOWN = 0x0001;

  public const ushort RI_MOUSE_BUTTON_1_UP = 0x0002;
  public const ushort RI_MOUSE_LEFT_BUTTON_UP = 0x0002;

  public const ushort RI_MOUSE_BUTTON_2_DOWN = 0x0004;
  public const ushort RI_MOUSE_RIGHT_BUTTON_DOWN = 0x0004;

  public const ushort RI_MOUSE_BUTTON_2_UP = 0x0008;
  public const ushort RI_MOUSE_RIGHT_BUTTON_UP = 0x0008;

  public const ushort RI_MOUSE_BUTTON_3_DOWN = 0x0010;
  public const ushort RI_MOUSE_MIDDLE_BUTTON_DOWN = 0x0010;
  public const ushort RI_MOUSE_BUTTON_3_UP = 0x0020;
  public const ushort RI_MOUSE_MIDDLE_BUTTON_UP = 0x0020;

  public const ushort RI_MOUSE_BUTTON_4_DOWN = 0x0040;
  public const ushort RI_MOUSE_BUTTON_4_UP = 0x0080;
  public const ushort RI_MOUSE_BUTTON_5_DOWN = 0x0100;
  public const ushort RI_MOUSE_BUTTON_5_UP = 0x0200;
  public const ushort RI_MOUSE_WHEEL = 0x0400;
  public const ushort RI_MOUSE_HWHEEL = 0x0800;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawkeyboard
  public const ushort RI_KEY_MAKE =  0;
  public const ushort RI_KEY_BREAK =  1;
  public const ushort RI_KEY_E0 =  2;
  public const ushort RI_KEY_E1 =  4;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics
  public const int SM_XVIRTUALSCREEN = 76;
  public const int SM_YVIRTUALSCREEN = 77;
  public const int SM_CXVIRTUALSCREEN = 78;
  public const int SM_CYVIRTUALSCREEN = 79;
  public const int SM_CXSCREEN = 0;
  public const int SM_CYSCREEN = 1;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfow
  public const int SPI_GETMOUSESPEED = 0x0070;
  public const int SPI_GETMOUSE = 0x0003;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input
  public const UInt32 INPUT_MOUSE = 0;
  public const UInt32 INPUT_KEYBOARD = 1;
  public const UInt32 INPUT_HARDWARE = 2;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput
  public const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
  public const UInt32 KEYEVENTF_KEYUP = 0x0002;
  public const UInt32 KEYEVENTF_SCANCODE = 0x0008;
  public const UInt32 KEYEVENTF_UNICODE = 0x0004;

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
  public const UInt32 MOUSEEVENTF_MOVE = 0x0001;
  public const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
  public const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
  public const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
  public const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
  public const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;
  public const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;
  public const UInt32 MOUSEEVENTF_XDOWN = 0x0080;
  public const UInt32 MOUSEEVENTF_XUP = 0x0100;
  public const UInt32 MOUSEEVENTF_WHEEL = 0x0800;
  public const UInt32 MOUSEEVENTF_HWHEEL = 0x1000;
  public const UInt32 MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000;
  public const UInt32 MOUSEEVENTF_VIRTUALDESK = 0x4000;
  public const UInt32 MOUSEEVENTF_ABSOLUTE = 0x8000;

  // https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN
  public const int VK_LBUTTON = 0x01;
  public const int VK_RBUTTON = 0x02;
  public const int VK_MBUTTON = 0x04;
  public const int VK_XBUTTON1 = 0x05;
  public const int VK_XBUTTON2 = 0x06;

  // -------------------------------------------------------------------------
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerclassexw
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassExW")]
  public static extern System.UInt16 RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defwindowprocw
  [DllImport("user32.dll")]
  public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowexw
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowExW")]
  public static extern IntPtr CreateWindowEx(int dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, UInt32 dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroywindow
  [DllImport("user32.dll", SetLastError = true)]
  [return:MarshalAs(UnmanagedType.Bool)] public static extern bool DestroyWindow(IntPtr hWnd);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unregisterclassw
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "UnregisterClassW")]
  [return:MarshalAs(UnmanagedType.Bool)] public static extern bool UnregisterClass([MarshalAs(UnmanagedType.LPWStr)] string lpClassName, IntPtr hInstance);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerrawinputdevices
  [DllImport("user32.dll", SetLastError = true)]
  [return:MarshalAs(UnmanagedType.Bool)] public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessage
  [DllImport("user32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)] public static extern bool GetMessage(ref MSG lpMsg, IntPtr hWnd, IntPtr wMsgFilterMin, IntPtr wMsgFilterMax);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-waitmessage
  [DllImport("user32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)] public static extern bool WaitMessage();

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-peekmessagew
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "PeekMessageW")]
  [return: MarshalAs(UnmanagedType.Bool)] public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-translatemessage
  [DllImport("user32.dll", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)] public static extern bool TranslateMessage([In] ref MSG lpMsg);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dispatchmessage
  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postquitmessage
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "PeekMessageW")]
  public static extern void PostQuitMessage(int nExitCode);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdevicelist
  [DllImport("user32.dll", SetLastError = true)]
  public static extern uint GetRawInputDeviceList([In, Out] RAWINPUTDEVICELIST[] pRawInputDeviceList, ref uint puiNumDevices, uint cbSize);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdeviceinfow
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetRawInputDeviceInfoW")]
  public static extern uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdata
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetRawInputData")]
  public static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, [Out] IntPtr pData, [In, Out] ref uint pcbSize, uint cbSizeHeader);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetSystemMetrics")]
  public static extern int GetSystemMetrics(int nIndex);

  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfow
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "SystemParametersInfoW")]
  [return: MarshalAs(UnmanagedType.Bool)] public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, [In, Out] IntPtr pvParam, uint fWinIni);

  // -------------------------------------------------------------------------
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "SendInput")]
  public static extern int SendInput(int cInputs, [In] INPUT[] pInputs, int cbSize);

  // ---------------------------------------------------------------------------
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessageextrainfo
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetMessageExtraInfo")]
  public static extern IntPtr GetMessageExtraInfo();

  // ---------------------------------------------------------------------------
  // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos
  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetCursorPos")]
  [return : MarshalAs(UnmanagedType.Bool)] public static extern bool GetCursorPos([In, Out] ref POINT lpPoint);

  [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetKeyState")]
  public static extern short GetKeyState(int nVirtKey);
}

} // End of namespace th.simio
