/* ----------------------------------------------------------------------- *

    * Kernel32.cs

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

namespace th.simio {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/// <summary>
/// Kernel32.dll
/// </summary>
public static class Kernel32
{
  // https://docs.microsoft.com/en-us/windows/win32/secauthz/access-mask-format
  public const UInt32 GENERIC_READ = 0x80000000;
  public const UInt32 GENERIC_WRITE = 0x40000000;

  // https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew
  public const UInt32 FILE_SHARE_DELETE = 0x00000004;
  public const UInt32 FILE_SHARE_READ = 0x00000001;
  public const UInt32 FILE_SHARE_WRITE = 0x00000002;

  // https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew
  public const UInt32 CREATE_ALWAYS = 2;
  public const UInt32 CREATE_NEW = 1;
  public const UInt32 OPEN_ALWAYS = 4;
  public const UInt32 OPEN_EXISTING = 3;
  public const UInt32 TRUNCATE_EXISTING = 5;

  // ---------------------------------------------------------------------------
  // https://docs.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlew
  [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "GetModuleHandleW")]
  public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

  // https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew
  [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "CreateFileW")]
  public static extern IntPtr CreateFile([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName, UInt32 dwDesiredAccess, UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

  // https://docs.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle
  [DllImport("Kernel32.dll", SetLastError = true)]
  [return : MarshalAs(UnmanagedType.Bool)] public static extern bool CloseHandle(IntPtr hObject);
}

} // End of namespace th.simio
