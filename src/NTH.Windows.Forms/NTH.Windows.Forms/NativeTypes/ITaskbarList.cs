using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NTH.Windows.Forms.NativeTypes
{
    [Guid("56FDF342-FD6D-11d0-958A-006097C9A090")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //[SecurityCritical(SecurityCriticalScope.Everything)]
    [SuppressUnmanagedCodeSecurity]
    [ComImport]
    internal interface ITaskbarList
    {
        void HrInit();
        void AddTab(IntPtr hwnd);
        void DeleteTab(IntPtr hwnd);
        void ActivateTab(IntPtr hwnd);
        void SetActiveAlt(IntPtr hwnd);
    }
}
