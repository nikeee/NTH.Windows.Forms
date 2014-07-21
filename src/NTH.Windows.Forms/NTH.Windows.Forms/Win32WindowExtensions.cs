using System;
using System.Windows.Forms;
using NTH.Windows.Forms.NativeTypes;

namespace NTH.Windows.Forms
{
    public static class Win32WindowExtensions
    {
        public static void Flash(this IWin32Window window)
        {
            if (window == null)
                throw new NullReferenceException();
            var info = new FlashWindowInfo(window.Handle);
            info.Flash();
        }
    }
}
