using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DCT_2
{
    public class Picture
    {
        Sprite s;
        DCT d;
        UInt64 hash;

        public UInt64 Hash { get { return hash; } }
        public Sprite Images { get { return s; } }

        public Picture(string path)
        {
            s = new Sprite(path);
            d = new DCT(32);
            d.GetDCT(s.LineData);
            hash = d.DCTtoInt64();
        }
        public Picture(Image img)
        {
            s = new Sprite(img);
            d = new DCT(32);
            d.GetDCT(s.LineData);
            hash = d.DCTtoInt64();
        }

        public Point GetPictures(Control.ControlCollection c, int x, int y)
        {
            int dx = x; int dy = y;
            c.Add(s.GetPicture(dx,dy));
            dx += 3 + s.SourceImage.Width;
            c.Add(s.GetSmallPicture(dx, dy));
            dx += 3 + s.ScaledImage.Width;
            c.Add(s.GetGrayPicture(dx,dy));
            dx += 3 + s.ScaledImage.Width;
            c.Add(d.GetPicture(dx, dy));
            dx += 3 + d.Dct.GetLength(1);
            c.Add(d.GetHashPicture(dx, dy));
            dx += 3 + d.BitDct.GetLength(1);
            return new Point(dx, dy + s.SourceImage.Height);
        }

        public static int Distance(Picture a, Picture b)
        {
            ulong dhash = a.Hash ^ b.Hash;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                if ((dhash >> i & (ulong)1) == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            return hash.ToString();
        }
    }
}
