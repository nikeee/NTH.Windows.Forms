using System;

namespace NTH.Windows.Forms.NativeTypes
{
    internal struct CredentialUiInfo
    {
        public int cbSize;
        public IntPtr hwndParent;
        public string pszMessageText;
        public string pszCaptionText;
        public IntPtr hbmBanner;
    }
}
