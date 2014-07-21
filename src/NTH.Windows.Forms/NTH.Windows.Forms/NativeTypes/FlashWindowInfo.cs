using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NTH.Windows.Forms.NativeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct FlashWindowInfo
    {
        public UInt32 Size;
        public IntPtr WindowHandle;
        public FlashWindowFlags Flags;
        public UInt32 Count;
        public UInt32 Timeout;

        public FlashWindowInfo(IntPtr handle)
            : this(handle, FlashWindowFlags.TimerNoForeground | FlashWindowFlags.Tray, UInt32.MaxValue)
        { }
        public FlashWindowInfo(IntPtr handle, FlashWindowFlags flags, uint count)
            : this(handle, flags, count, 0)
        { }
        public FlashWindowInfo(IntPtr handle, FlashWindowFlags flags, uint count, uint timeout)
        {
            Size = Convert.ToUInt32(Marshal.SizeOf(typeof(FlashWindowInfo)));
            WindowHandle = handle;
            Flags = flags;
            Count = count;
            Timeout = timeout;
        }

        public void Flash()
        {
            NativeMethods.FlashWindowEx(ref this);
        }
    }
}
