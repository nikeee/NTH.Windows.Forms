using System;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public static class ControlExtensions
    {
        public static void InvokeOnUiThread(this Control control, Action action)
        {
            if (control == null)
                throw new NullReferenceException();
            if (action == null)
                throw new ArgumentNullException("action");

            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
