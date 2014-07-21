using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NTH.Windows.Forms.NativeTypes;

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
