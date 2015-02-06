using System;
using System.ComponentModel;
using System.Windows.Forms;
using NTH.Windows.Forms.NativeTypes;

namespace NTH.Windows.Forms
{
    public class PlaceholderTextbox : TextBox
    {
        private string _placeholder;
        private bool _retainPlaceholderOnFocus;

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

        public bool RetainPlaceholderOnFocus
        {
            get { return _retainPlaceholderOnFocus; }
            set
            {
                if (_retainPlaceholderOnFocus == value)
                    return;
                _retainPlaceholderOnFocus = value;
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
                NativeMethods.SendMessage(Handle, WindowMessage.EM_SETCUEBANNER, new IntPtr(_retainPlaceholderOnFocus ? 1 : 0), _placeholder);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdatePlaceholder();
        }
    }
}
