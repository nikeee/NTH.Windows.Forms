using System;
using System.Runtime.InteropServices;

namespace NTH.Windows.Forms.NativeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FlashWindowInfo
    {
        public UInt32 Size;
        public IntPtr WindowHandle;
        public FlashWindowFlags Flags;
        public UInt32 FlashCount;
        public UInt32 FlashRate;

        public FlashWindowInfo(IntPtr handle)
            : this(handle, FlashWindowFlags.TimerNoForeground | FlashWindowFlags.Tray, UInt32.MaxValue)
        { }
        public FlashWindowInfo(IntPtr handle, FlashWindowFlags flags, uint flashCount)
            : this(handle, flags, flashCount, 0)
        { }
        public FlashWindowInfo(IntPtr handle, FlashWindowFlags flags, uint flashCount, uint flashRate)
        {
            Size = Convert.ToUInt32(Marshal.SizeOf(typeof(FlashWindowInfo)));
            WindowHandle = handle;
            Flags = flags;
            FlashCount = flashCount;
            FlashRate = flashRate;
        }

        public void Flash()
        {
            NativeMethods.FlashWindowEx(ref this);
        }
    }
}
