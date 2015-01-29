using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class WindowUtil
    {
        public static string GetWindowTitle(IWin32Window window)
        {
            return GetWindowTitle(window.Handle);
        }

        public static string GetWindowTitle(IntPtr handle)
        {
            int length = NativeMethods.GetWindowTextLength(handle);
            var sb = new StringBuilder(length + 1);
            NativeMethods.GetWindowText(handle, sb, sb.Capacity);
            return sb.ToString();
        }

        /// <remarks>See: https://code.msdn.microsoft.com/windowsapps/Enumerate-top-level-9aa9d7c1 </remarks>
        public static IList<WindowItem> EnumerateWindows()
        {
            //NativeMethods.EnumWindows(EnumTheWindows, IntPtr.Zero);
            var list = new List<WindowItem>();
            NativeMethods.EnumWindows((handle, lParam) =>
                                      {
                                          var title = GetWindowTitle(handle);
                                          list.Add(new WindowItem(handle, title));
                                          return true;
                                      }, IntPtr.Zero);
            return list;
        }

        public static IList<WindowItem> EnumerateVisibleWindows()
        {
            return EnumerateWindows().Where(window => !string.IsNullOrEmpty(window.Title) && NativeMethods.IsWindowVisible(window.Handle)).ToList();
        }
    }
}
