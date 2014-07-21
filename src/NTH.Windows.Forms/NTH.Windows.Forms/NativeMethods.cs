using System;
using NTH.Windows.Forms.NativeTypes;
using System.Runtime.InteropServices;

namespace NTH.Windows.Forms
{
    internal static class NativeMethods
    {
        private const string User32 = "User32.dll";

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FlashWindowEx(ref FlashWindowInfo flashWindowInfo);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, WindowMessage message, IntPtr wParam, IntPtr lParam);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, WindowMessage message, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }
}
