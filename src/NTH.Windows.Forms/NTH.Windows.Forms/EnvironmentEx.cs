using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NTH.Windows.Forms
{
    public static class EnvironmentEx
    {
        public static bool IsDwmSupported
        {
            get { return Environment.OSVersion.Version >= OsVersions.Vista; }
        }

        public static bool IsDwmEnabled
        {
            get
            {
                if (!IsDwmSupported)
                    return false;
                bool isEnabled;
                int result;
                if ((result = NativeMethods.DwmIsCompositionEnabled(out isEnabled)) != 0)
                    throw new Win32Exception(result);
                return isEnabled;
            }
        }
    }
}
