using System;
using System.ComponentModel;
using System.Windows.Forms;
using NTH.Windows.Forms.NativeTypes;

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
            if (IsHandleCreated)
                NativeMethods.SendMessage(Handle, WindowMessage.EM_SETCUEBANNER, new IntPtr(1), _placeholder);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdatePlaceholder();
        }
    }
}
