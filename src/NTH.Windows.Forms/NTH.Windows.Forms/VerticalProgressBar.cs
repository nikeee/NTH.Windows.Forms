using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var current = base.CreateParams;
                current.Style |= 0x4;
                return current;
            }
        }
    }
}
