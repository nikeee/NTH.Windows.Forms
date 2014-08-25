using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NTH.Windows.Forms.NativeTypes
{
    [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //[SecurityCritical(SecurityCriticalScope.Everything)]
    [SuppressUnmanagedCodeSecurity]
    [ComImport]
    internal interface ITaskbarList4 : ITaskbarList3, ITaskbarList2, ITaskbarList
    {
        void HrInit();
        void AddTab(IntPtr hwnd);
        void DeleteTab(IntPtr hwnd);
        void ActivateTab(IntPtr hwnd);
        void SetActiveAlt(IntPtr hwnd);
        void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
        [PreserveSig]
        HRESULT SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
        [PreserveSig]
        HRESULT SetProgressState(IntPtr hwnd, TBPF tbpFlags);
        [PreserveSig]
        HRESULT RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);
        [PreserveSig]
        HRESULT UnregisterTab(IntPtr hwndTab);
        [PreserveSig]
        HRESULT SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);
        [PreserveSig]
        HRESULT SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);
        [PreserveSig]
        HRESULT ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);
        [PreserveSig]
        HRESULT ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);
        [PreserveSig]
        HRESULT ThumbBarSetImageList(IntPtr hwnd, [MarshalAs(UnmanagedType.IUnknown)] object himl);
        [PreserveSig]
        HRESULT SetOverlayIcon(IntPtr hwnd, NativeMethods.IconHandle hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
        [PreserveSig]
        HRESULT SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        [PreserveSig]
        HRESULT SetThumbnailClip(IntPtr hwnd, NativeMethods.RefRECT prcClip);
        [PreserveSig]
        HRESULT SetTabProperties(IntPtr hwndTab, STPF stpFlags);
    }
}