using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NTH.Windows.Forms.NativeTypes;

namespace NTH.Windows.Forms
{
    public class NthListView : ListView
    {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
        private const int LVS_EX_DOUBLEBUFFER = 0x00010000;
        private bool _isExplorerListView;
        private bool _areGroupsCollapsable;

        public NthListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            FullRowSelect = true; // Customizable...
        }

        public bool AreGroupsCollapsable
        {
            get { return _areGroupsCollapsable; }
            set
            {
                if (_areGroupsCollapsable == value) 
                    return;
                _areGroupsCollapsable = value; // Or just initialize with the negated value, but "value" is shorter :)
                SetCollapsableState();
            }
        }

        private void SetCollapsableState()
        {
            if (Environment.OSVersion.Version.Major < 6)
                return;

            const int lvmFirst = 0x1000;
            const int LVM_SETGROUPINFO = (lvmFirst + 147);

            foreach (ListViewGroup group in Groups)
            {
                var placeHolderGroup = new NthListViewGroup();
                placeHolderGroup.CbSize = Marshal.SizeOf(placeHolderGroup);
                placeHolderGroup.State = _areGroupsCollapsable ? NthListViewGroupState.Collapsible : NthListViewGroupState.Normal;
                placeHolderGroup.Mask = NthListViewGroupMask.State;
                placeHolderGroup.GroupId = GetGroupId(group);

                if (placeHolderGroup.GroupId < 0) 
                    continue;
                //var handle = GCHandle.Alloc(placeHolderGroup, GCHandleType.Pinned);
                NativeMethods.SendMessage(Handle, LVM_SETGROUPINFO, new IntPtr(placeHolderGroup.GroupId),
                    ref placeHolderGroup);
                // TODO: Verify if the object is directly handled over by reference or just copied
                //handle.Free();
            }
        }

        private static int GetGroupId(ListViewGroup group)
        {
            var groupType = group.GetType();
            {
                var groupIdProperty = groupType.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance); // Include inner fields and instance members
                if (groupIdProperty == null)
                    return -1;
                var value = groupIdProperty.GetValue(group, null);
                if (value != null)
                    return (int)value;
            }
            return -1;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_LBUTTONUP = 0x202;
            if (m.Msg == WM_LBUTTONUP && Environment.OSVersion.Version.Major >= 6)
                DefWndProc(ref m);

            switch (m.Msg)
            {
                case 15:
                    if (!_isExplorerListView)
                    {
                        NativeMethods.SetWindowTheme(Handle, "explorer", null);
                        NativeMethods.SendMessage(Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, new IntPtr(LVS_EX_DOUBLEBUFFER),
                            new IntPtr(LVS_EX_DOUBLEBUFFER));
                        _isExplorerListView = true;
                    }
                    break;
            }

            base.WndProc(ref m);
        }
    }
}
