using NTH.Windows.Forms.NativeTypes;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NTH.Windows.Forms
{
    internal static class NativeMethods
    {
        private const string User32 = "User32.dll";
        private const string DwmApi = "dwmapi.dll";
        private const string CredUi = "credui.dll";

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

        [DllImport(DwmApi)]
        internal static extern int DwmIsCompositionEnabled(out bool enabled);

        [DllImport(CredUi)]
        internal static extern CredentialUiReturnCodes CredUIPromptForCredentials(ref CredentialUiInfo creditUR,
              string targetName,
              IntPtr reserved1,
              int iError,
              StringBuilder userName,
              int maxUserName,
              StringBuilder password,
              int maxPassword,
              [MarshalAs(UnmanagedType.Bool)] ref bool pfSave,
              CredentialUiFlags flags);
    }

    internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
}
