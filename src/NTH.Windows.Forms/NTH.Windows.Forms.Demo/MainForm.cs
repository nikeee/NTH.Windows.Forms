
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

        private void button2_Click(object sender, System.EventArgs e)
        {
            var dialog = new CredentialDialog("Demo Application");
            var creds = dialog.RequestUserCredentials();
            if (creds != null)
            {
                MessageBox.Show(string.Format("Username: {0}\r\nPassword: {1}", creds.Username ?? string.Empty,
                    creds.Password ?? string.Empty));
            }
            else
            {
                MessageBox.Show("Got no credentials");
            }
        }
    }
}
