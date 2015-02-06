using System;
using System.Drawing;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public sealed class NthLinkLabel : LinkLabel
    {
        private const LinkBehavior NthDefaultLinkBehavior = LinkBehavior.HoverUnderline;
        private static readonly Color NthDefaultLinkColor = SystemColors.HotTrack;
        private static readonly Color NthDefaultActiveLinkColor = SystemColors.Highlight;
        private static readonly Cursor NthDefaultCursor = Cursors.Hand;

        public NthLinkLabel()
        {
            LinkBehavior = NthDefaultLinkBehavior;
            LinkColor = NthDefaultLinkColor;
            ActiveLinkColor = NthDefaultActiveLinkColor;
            Cursor = NthDefaultCursor; // Class is marked as sealed because of virtual member call in ctor (can of course be changed)
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            LinkColor = NthDefaultActiveLinkColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            LinkColor = NthDefaultLinkColor;
        }
    }
}
