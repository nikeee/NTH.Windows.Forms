using System.Drawing;
using System.IO;

namespace NTH.Windows.Forms
{
    internal static class IconExtensions
    {
        public static Icon GetSize(this Icon icon, int width, int height)
        {
            return icon.GetSize(new Size(width, height));
        }

        public static Icon GetSize(this Icon icon, Size size)
        {
            using (var mem = new MemoryStream())
            {
                icon.Save(mem);
                mem.Position = 0;
                return new Icon(mem, size);
            }
        }
    }
}
