using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    // TODO: Support non-vista systems, currently only Vista+ is supported with the following code
    public class NthListView : ListView
    {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
        private const int LVS_EX_DOUBLEBUFFER = 0x00010000;
        private bool _isExplorerListView;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var cp = base.CreateParams;
        //        if(Environment.OSVersion.Version.Major >= 6)
        //            cp |= 0; // TODO
        //        return cp;
        //    }
        //}

        public NthListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //if (Environment.OSVersion.Version.Major < 6)
            //    SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();

            FullRowSelect = true; // Customizable...
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (GetStyle(ControlStyles.UserPaint))
        //    {
        //        Message m = new Message
        //        {
        //            HWnd = Handle,
        //            Msg = WM_PRINTCLIENT,
        //            WParam = e.Graphics.GetHdc(),
        //            LParam = (IntPtr) PRF_CLIENT
        //        };
        //        DefWndProc(ref m);
        //        e.Graphics.ReleaseHdc(m.WParam);
        //    }
        //    base.OnPaint(e);
        //}

        public void MakeCollapsable() // Adds expanders to the groups, should be called in form's Show-event
        {
            if (Environment.OSVersion.Version.Major < 6)
                return;

            const int lvmFirst = 0x1000;
            const int LVM_SETGROUPINFO = (lvmFirst + 147);

            foreach (ListViewGroup group in Groups)
            {
                var placeHolderGroup = new NthListViewGroup();
                placeHolderGroup.CbSize = Marshal.SizeOf(placeHolderGroup);
                placeHolderGroup.State = NthListViewGroupState.Collapsible;
                placeHolderGroup.Mask = NthListViewGroupMask.State;
                placeHolderGroup.GroupId = GetGroupId(group);

                if (placeHolderGroup.GroupId >= 0)
                    NativeMethods.SendMessage(Handle, LVM_SETGROUPINFO, new IntPtr(placeHolderGroup.GroupId), ref placeHolderGroup);
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
