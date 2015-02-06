using System;
using System.Runtime.InteropServices;
using System.Text;
using NTH.Windows.Forms.NativeTypes;

namespace NTH.Windows.Forms
{
    internal static class NativeMethods
    {
        private const string User32 = "User32.dll";
        private const string DwmApi = "dwmapi.dll";
        private const string UxTheme = "Uxtheme.dll";

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FlashWindowEx(ref FlashWindowInfo flashWindowInfo);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, WindowMessage message, IntPtr wParam, IntPtr lParam);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr windowHandle, WindowMessage message, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref NthListViewGroup lParam);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport(User32, CharSet = CharSet.Unicode)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport(UxTheme, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport(User32)]
        internal static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport(User32)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport(DwmApi)]
        internal static extern int DwmIsCompositionEnabled(out bool enabled);
    }

    internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
}
