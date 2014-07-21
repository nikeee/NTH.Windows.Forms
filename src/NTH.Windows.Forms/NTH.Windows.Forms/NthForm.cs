using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class NthForm : Form
    {
        private static readonly Color DefaultBackgroundColor = SystemColors.Window;

        [DefaultValue(typeof(SystemColors), "Window")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public NthForm()
        {
            base.BackColor = DefaultBackgroundColor;
        }
    }
}
