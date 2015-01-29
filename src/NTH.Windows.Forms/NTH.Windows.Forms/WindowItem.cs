using System;

namespace NTH.Windows.Forms
{
    public class WindowItem
    {
        public string Title { get; private set; }
        public IntPtr Handle { get; set; }

        //public ImageSource Icon { get; set; }

        internal WindowItem(IntPtr handle, string title)
        {
            Handle = handle;
            Title = WindowUtil.GetWindowTitle(Handle);
            //Icon = IconUtil.GetIcon(Handle);
        }
    }
}
