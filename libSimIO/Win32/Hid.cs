/* ----------------------------------------------------------------------- *

    * Hid.cs

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
public static class Hid
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ne-hidpi-_hidp_report_type
  public enum HIDP_REPORT_TYPE : int
  {
    HidP_Input,
    HidP_Output,
    HidP_Feature
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_caps
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct HIDP_CAPS
  {
    public HidUsage.Usage  Usage;
    public HidUsage.UsagePage  UsagePage;
    public UInt16 InputReportByteLength;
    public UInt16 OutputReportByteLength;
    public UInt16 FeatureReportByteLength;
    public fixed UInt16 Reserved[17];
    public UInt16 NumberLinkCollectionNodes;
    public UInt16 NumberInputButtonCaps;
    public UInt16 NumberInputValueCaps;
    public UInt16 NumberInputDataIndices;
    public UInt16 NumberOutputButtonCaps;
    public UInt16 NumberOutputValueCaps;
    public UInt16 NumberOutputDataIndices;
    public UInt16 NumberFeatureButtonCaps;
    public UInt16 NumberFeatureValueCaps;
    public UInt16 NumberFeatureDataIndices;
  };

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct HidCapsRange
  {
    public HidUsage.Usage UsageMin;
    public HidUsage.Usage UsageMax;
    public UInt16 StringMin;
    public UInt16 StringMax;
    public UInt16 DesignatorMin;
    public UInt16 DesignatorMax;
    public UInt16 DataIndexMin;
    public UInt16 DataIndexMax;
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct HidCapsNotRange
  {
    public HidUsage.Usage Usage;
    public UInt16 Reserved1;
    public UInt16 StringIndex;
    public UInt16 Reserved2;
    public UInt16 DesignatorIndex;
    public UInt16 Reserved3;
    public UInt16 DataIndex;
    public UInt16 Reserved4;
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_button_caps
  [StructLayout(LayoutKind.Explicit)]
  public unsafe struct HIDP_BUTTON_CAPS
  {
    [FieldOffset(0)] public HidUsage.UsagePage UsagePage;
    [FieldOffset(2)] public byte ReportID;
    [FieldOffset(3), MarshalAs(UnmanagedType.Bool)] public bool IsAlias;
    [FieldOffset(4)] public UInt16 BitField;
    [FieldOffset(6)] public UInt16 LinkCollection;
    [FieldOffset(8)] public HidUsage.Usage LinkUsage;
    [FieldOffset(10)] HidUsage.UsagePage LinkUsagePage;
    [FieldOffset(12), MarshalAs(UnmanagedType.Bool)] public bool IsRange;
    [FieldOffset(13), MarshalAs(UnmanagedType.Bool)] public bool IsStringRange;
    [FieldOffset(14), MarshalAs(UnmanagedType.Bool)] public bool IsDesignatorRange;
    [FieldOffset(15), MarshalAs(UnmanagedType.Bool)] public bool IsAbsolute;
    [FieldOffset(16)] public UInt16 ReportCount;
    [FieldOffset(18)] public UInt16 Reserved2;
    [FieldOffset(20)] public fixed UInt32 Reserved[9];
    [FieldOffset(56)] public HidCapsRange Range;
    [FieldOffset(56)] public HidCapsNotRange NotRange;
  }

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_button_caps
  [StructLayout(LayoutKind.Explicit)]
  public unsafe struct HIDP_VALUE_CAPS
  {
    [FieldOffset(0)] public HidUsage.UsagePage UsagePage;
    [FieldOffset(2)] public byte ReportID;
    [FieldOffset(3)] public bool IsAlias;
    [FieldOffset(4)] public UInt16 BitField;
    [FieldOffset(6)] public UInt16 LinkCollection;
    [FieldOffset(8)] public HidUsage.Usage LinkUsage;
    [FieldOffset(10)] public HidUsage.UsagePage LinkUsagePage;
    [FieldOffset(12)] public bool IsRange;
    [FieldOffset(13)] public bool IsStringRange;
    [FieldOffset(14)] public bool IsDesignatorRange;
    [FieldOffset(15)] public bool IsAbsolute;
    [FieldOffset(16)] public bool HasNull;
    [FieldOffset(17)] public byte Reserved;
    [FieldOffset(18)] public UInt16 BitSize;
    [FieldOffset(20)] public UInt16 ReportCount;
    [FieldOffset(22)] public fixed UInt16 Reserved2[5];
    [FieldOffset(32)] public UInt32 UnitsExp;
    [FieldOffset(36)] public UInt32 Units;
    [FieldOffset(40)] public Int32 LogicalMin;
    [FieldOffset(44)] public Int32 LogicalMax;
    [FieldOffset(48)] public Int32 PhysicalMin;
    [FieldOffset(52)] public Int32 PhysicalMax;
    [FieldOffset(56)] public HidCapsRange Range;
    [FieldOffset(56)] public HidCapsNotRange NotRange;
  }

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getproductstring
  [DllImport("Hid.dll", SetLastError = true)]
  [return : MarshalAs(UnmanagedType.Bool)] public static extern bool HidD_GetProductString(IntPtr HidDeviceObject, [Out] IntPtr Buffer, UInt32  BufferLength);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getmanufacturerstring
  [DllImport("Hid.dll", SetLastError = true)]
  [return : MarshalAs(UnmanagedType.Bool)] public static extern bool HidD_GetManufacturerString(IntPtr HidDeviceObject, IntPtr Buffer, UInt32 BufferLength);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getcaps
  [DllImport("Hid.dll", SetLastError = true)]
  public static extern UInt32 HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getbuttoncaps
  [DllImport("Hid.dll", SetLastError = true)]
  public unsafe static extern UInt32 HidP_GetButtonCaps(HIDP_REPORT_TYPE ReportType, HIDP_BUTTON_CAPS *ButtonCaps, UInt16 *ButtonCapsLength, IntPtr PreparsedData);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusages
  [DllImport("Hid.dll", SetLastError = true)]
  public unsafe static extern UInt32 HidP_GetUsages(HIDP_REPORT_TYPE ReportType, HidUsage.UsagePage UsagePage, UInt16 LinkCollection, UInt16 *UsageList, ref UInt32 UsageLength, IntPtr PreparsedData, [Out] byte *report, UInt32 ReportLength);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getvaluecaps
  [DllImport("Hid.dll", SetLastError = true)]
  public unsafe static extern UInt32 HidP_GetValueCaps(HIDP_REPORT_TYPE ReportType, HIDP_VALUE_CAPS *ValueCaps, ref UInt16 ValueCapsLength, IntPtr PreparsedData);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusagevalue
  [DllImport("Hid.dll", SetLastError = true)]
  public unsafe static extern UInt32 HidP_GetUsageValue(HIDP_REPORT_TYPE ReportType, HidUsage.UsagePage UsagePage, UInt16 LinkCollection, HidUsage.Usage Usage, UInt32 *UsageValue, IntPtr PreparsedData, byte *Report, UInt32 ReportLength);

  // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getscaledusagevalue
  [DllImport("Hid.dll", SetLastError = true)]
  public unsafe static extern UInt32 HidP_GetScaledUsageValue(HIDP_REPORT_TYPE ReportType, HidUsage.UsagePage UsagePage, UInt16 LinkCollection, HidUsage.Usage Usage, Int32 *UsageValue, IntPtr PreparsedData, byte *Report, UInt32 ReportLength);
}

} // End of namespace th.simio
