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
            get
            {
                // If running on Linux or Mac or XBox, there will be no (Windows-)DWM.
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return false;
                return Environment.OSVersion.Version >= OsVersions.Vista;
            }
        }

        internal static bool IsWindowsEightOrHigher
        {
            get { return Environment.OSVersion.Version >= OsVersions.Eight; }
        }

        public static bool IsDwmEnabled
        {
            get
            {
                if (!IsDwmSupported)
                    return false;

                // Note: As of Windows 8, DWM composition is always enabled.
                // Source: https://msdn.microsoft.com/en-us/library/windows/desktop/aa969518%28v=vs.85%29.aspx
                if (IsWindowsEightOrHigher)
                    return true;

                // So the API call is only necessary when using Windows 7 or Windows Vista.

                bool isEnabled;
                int result;
                if ((result = NativeMethods.DwmIsCompositionEnabled(out isEnabled)) != 0)
                    throw new Win32Exception(result);
                return isEnabled;
            }
        }
    }
}
