using NTH.Windows.Forms.NativeTypes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class PlaceholderTextbox : TextBox
    {
        private string _placeholder;

        [Browsable(true)]
        [Description("The placeholder text which is being displayed if no text is entered.")]
        public string Placeholder
        {
            get
            {
                return _placeholder;
            }
            set
            {
                if (_placeholder == value)
                    return;
                _placeholder = value;
                UpdatePlaceholder();
            }
        }

        public PlaceholderTextbox()
        {
            UpdatePlaceholder();
        }

        private void UpdatePlaceholder()
        {
            var currentHandle = Handle;
            if (currentHandle != IntPtr.Zero)
                NativeMethods.SendMessage(currentHandle, WindowMessage.EM_SETCUEBANNER, IntPtr.Zero, _placeholder);
        }
    }
}
