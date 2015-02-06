
using System.Windows.Forms;

namespace NTH.Windows.Forms.Demo
{
    public partial class MainForm : NthForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.Flash(3);
        }

        private void MainForm_Shown(object sender, System.EventArgs e)
        {
            nthListView1.MakeCollapsable();
        }
    }
}
