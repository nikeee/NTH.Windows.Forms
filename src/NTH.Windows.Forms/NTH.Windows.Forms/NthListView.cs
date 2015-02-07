using NTH.Windows.Forms.NativeTypes;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class NthListView : ListView
    {
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

            foreach (ListViewGroup group in Groups)
            {
                var placeHolderGroup = new NthListViewGroup();
                placeHolderGroup.CbSize = Marshal.SizeOf(placeHolderGroup);
                placeHolderGroup.State = _areGroupsCollapsable ? NthListViewGroupState.Collapsible : NthListViewGroupState.Normal;
                placeHolderGroup.Mask = NthListViewGroupMask.State;
                placeHolderGroup.GroupId = GetGroupId(group);

                if (placeHolderGroup.GroupId < 0)
                    continue;

                NativeMethods.SendMessage(Handle, (int)LVM.LVM_SETGROUPINFO, new IntPtr(placeHolderGroup.GroupId), ref placeHolderGroup);
                // TODO: Verify if the object is directly handled over by reference or just copied

            }
        }

        private static int GetGroupId(ListViewGroup group)
        {
            var groupType = group.GetType();

            // Include inner fields and instance members
            var groupIdProperty = groupType.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
            if (groupIdProperty == null)
                return -1;
            var value = groupIdProperty.GetValue(group, null);
            if (value != null)
                return (int)value;

            return -1;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_LBUTTONUP && Environment.OSVersion.Version >= OsVersions.Vista)
                DefWndProc(ref m);

            switch (m.Msg)
            {
                case 15:
                    if (!_isExplorerListView)
                    {
                        NativeMethods.SetWindowTheme(Handle, "explorer", null);
                        NativeMethods.SendMessage(Handle, (int)LVM.LVM_SETEXTENDEDLISTVIEWSTYLE, new IntPtr((int)LVM.LVS_EX_DOUBLEBUFFER), new IntPtr((int)LVM.LVS_EX_DOUBLEBUFFER));
                        _isExplorerListView = true;
                    }
                    break;
            }

            base.WndProc(ref m);
        }


        private enum LVM
        {
            LVM_FIRST = 0x1000,
            LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 0x36,
            LVS_EX_DOUBLEBUFFER = 0x00010000,
            LVM_SETGROUPINFO = LVM_FIRST + 0x93
        }
    }
}
