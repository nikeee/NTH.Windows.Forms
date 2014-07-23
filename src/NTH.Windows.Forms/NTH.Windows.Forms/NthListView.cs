using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    // TODO
    public class NthListView : ListView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                if(Environment.OSVersion.Version.Major >= 6)
                    cp |= 0; // TODO
                return cp;
            }
        }
        public NthListView()
        {
            SetBuffingOptions();
        }

        private void SetBuffingOptions()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-Vista systems
            if (Environment.OSVersion.Version.Major < 6)
                SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                Message m = new Message();
                m.HWnd = Handle;
                m.Msg = WM_PRINTCLIENT;
                m.WParam = e.Graphics.GetHdc();
                m.LParam = (IntPtr)PRF_CLIENT;
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }
    }
}
