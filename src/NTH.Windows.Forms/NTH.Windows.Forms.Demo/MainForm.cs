
using System.Deployment.Application;
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
            nthListView1.AreGroupsCollapsable = true;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            nthListView1.AreGroupsCollapsable = false;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            nthListView1.AreGroupsCollapsable = true;
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            placeholderTextbox1.RetainPlaceholderOnFocus = checkBox1.Checked;
        }
    }
}
