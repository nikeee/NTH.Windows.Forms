using System;
using System.Text;
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

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport(User32)]
        internal static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport(User32)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);
    }

    internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
}
