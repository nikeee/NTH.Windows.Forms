using NTH.Windows.Forms.NativeTypes;
using System;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public static class Win32WindowExtensions
    {
        public static void Flash(this IWin32Window window)
        {
            window.Flash(int.MaxValue);
        }

        public static void Flash(this IWin32Window window, int count)
        {
            window.Flash(count, FlashWindowFlags.TimerNoForeground | FlashWindowFlags.Tray);
        }

        public static void Flash(this IWin32Window window, int count, FlashWindowFlags flashWindowFlags)
        {
            if (window == null)
                throw new NullReferenceException();
            var info = new FlashWindowInfo(window.Handle, flashWindowFlags, (uint)count);
            info.Flash();
        }
    }
}
