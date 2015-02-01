
using System;
using System.Runtime.InteropServices;
using System.Text;
using NTH.Windows.Forms.NativeTypes;

namespace NTH.Windows.Forms
{
    public class CredentialDialog
    {
        private readonly string _applicationName;
        public CredentialDialog(string applicationName)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
                throw new ArgumentNullException("applicationName");
            _applicationName = applicationName;
        }

        public Credentials RequestUserCredentials()
        {
            if (Environment.OSVersion.Version < OsVersions.Vista)
                return DisplayLegacyDialog();

            // Should use this here:
            // https://msdn.microsoft.com/en-us/library/windows/desktop/aa375178%28v=vs.85%29.aspx
            // (only supported by >= vista)
            throw new NotImplementedException();
        }

        private Credentials DisplayLegacyDialog()
        {
            const int maxUserNameLength = 100;
            const int maxPasswordLength = maxUserNameLength;

            var password = new StringBuilder();
            var userName = new StringBuilder();

            var credUi = new CredentialUiInfo();
            credUi.cbSize = Marshal.SizeOf(credUi);

            bool save = false;
            const CredentialUiFlags flags = CredentialUiFlags.ALWAYS_SHOW_UI | CredentialUiFlags.GENERIC_CREDENTIALS;
            // Prompt the user
            var returnCode = NativeMethods.CredUIPromptForCredentials(ref credUi, _applicationName, IntPtr.Zero, 0, userName, maxUserNameLength, password, maxPasswordLength, ref save, flags);


            if (returnCode == CredentialUiReturnCodes.NO_ERROR)
                return new Credentials(userName.ToString(), password.ToString());
            return null;
        }
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials()
            : this(null)
        { }
        public Credentials(string username)
            : this(username, null)
        { }
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
