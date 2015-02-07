using System;
using System.Runtime.InteropServices;

namespace NTH.Windows.Forms.NativeTypes
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct NthListViewGroup
    {
        public int CbSize;
        public NthListViewGroupMask Mask;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string PszHeader;
        public int CchHeader;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string PszFooter;
        public int CchFooter;
        public int GroupId;
        public int StateMask;
        public NthListViewGroupState State;
        public uint UAlign;
        public IntPtr PszSubtitle;
        public uint CchSubtitle;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string PszTask;
        public uint CchTask;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string PszDescriptionTop;
        public uint CchDescriptionTop;
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string PszDescriptionBottom;
        public uint CchDescriptionBottom;
        public int TitleImage;
        public int ExtendedImage;
        public int FirstItem;
        public IntPtr CItems;
        public IntPtr PszSubsetTitle;
        public IntPtr CchSubsetTitle;
    }

    internal enum NthListViewGroupMask
    {
        None = 0x0,
        Header = 0x1,
        Footer = 0x2,
        State = 0x4,
        Align = 0x8,
        GroupId = 0x10,
        SubTitle = 0x100,
        Task = 0x200,
        DescriptionTop = 0x400,
        DescriptionBottom = 0x800,
        TitleImage = 0x1000,
        ExtendedImage = 0x2000,
        Items = 0x4000,
        Subset = 0x8000,
        SubsetItems = 0x10000
    }

    internal enum NthListViewGroupState
    {
        Normal = 0,
        Collapsed = 1,
        Hidden = 2,
        NoHeader = 4,
        Collapsible = 8,
        Focused = 16,
        Selected = 32,
        SubSet = 64,
        SubSetLinkFocused = 128
    }
}
