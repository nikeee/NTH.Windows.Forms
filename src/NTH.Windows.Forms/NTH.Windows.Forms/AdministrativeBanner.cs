using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTH.Windows.Forms
{
    public class AdministrativeBanner : Control
    {
        private static readonly Color NthDefaultBackgroundColor = Color.FromArgb(255, 255, 255, 198);
        //private static readonly SolidBrush NthDefaultBackgroundBrush = new SolidBrush(NthDefaultBackgroundColor);
        private static readonly Color NthDefaultBorderColor = Color.FromArgb(171, 175, 218);
        private static readonly Pen NthDefaultBorderPen = new Pen(NthDefaultBorderColor);
        private static readonly BannerImage NthDefaultImage = BannerImage.Information;

        private const int NthDefaultHeight = 25;

        [DefaultValue(NthDefaultHeight)]
        public new int Height { get { return base.Height; } set { base.Height = value; } }

        [DefaultValue(typeof(BannerImage), "Information")]
        [Browsable(true)]
        public BannerImage Image { get; set; }

        public AdministrativeBanner()
        {
            Height = NthDefaultHeight;
            Image = NthDefaultImage;
        }

        private Rectangle GetIconRectangle()
        {
            return new Rectangle(0, 0, 16, 16);
        }

        private Image GetBannerImageObject(Size targetSize)
        {
            var icon = GetCurrentBannerIcon();
            if (icon == null)
                return null;
            return new Icon(icon, targetSize).ToBitmap();
        }

        private Icon GetCurrentBannerIcon()
        {
            switch (Image)
            {
                case BannerImage.Error:
                    return SystemIcons.Error;
                case BannerImage.Question:
                    return SystemIcons.Question;
                case BannerImage.Information:
                    return SystemIcons.Information;
                case BannerImage.Warning:
                    return SystemIcons.Warning;
                default:
                    return null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(NthDefaultBackgroundColor);
            e.Graphics.DrawRectangle(NthDefaultBorderPen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            if (Image != BannerImage.None)
            {
                var rect = GetIconRectangle();
                var img = GetBannerImageObject(rect.Size);
                e.Graphics.DrawImage(img, rect);

            }
            else
            {
                // TODO
            }
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor);
        }
    }

    public enum BannerImage
    {
        None,
        Error,
        Warning,
        Information,
        Question
    }
}
