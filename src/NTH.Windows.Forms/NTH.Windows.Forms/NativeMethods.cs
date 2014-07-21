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
    }
}
