using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class NthForm : Form
    {
        private static readonly Color NthDefaultBackColor = SystemColors.Window;
        private static readonly Font NthDefaultFont = SystemFonts.MessageBoxFont;

        [DefaultValue(typeof(SystemColors), "Window")]
        public override Color BackColor { get { return base.BackColor; } set { base.BackColor = value; } }

        [DefaultValue(typeof(SystemFonts), "MessageBoxFont")]
        public override Font Font { get { return base.Font; } set { base.Font = value; } }

        public NthForm()
        {
            base.BackColor = NthDefaultBackColor;
            base.Font = NthDefaultFont;
        }
    }
}
