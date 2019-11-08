using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DCT_2
{
    public class DCT
    {
        double[,] dct;
        double[,] cos;
        int[,] bitDct;
        int n;
        static int amount = 0;

        public double[,] Cos { get { return cos; } }
        public int N { get { return n; } }
        public double[,] Dct { get { return dct; } }
        public int[,] BitDct { get { return bitDct; } }

        public DCT(int N)
        {
            n = N;
            cos = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cos[i, j] = Math.Cos((2 * j + 1) * Math.PI * i / (2 * n));
                }
            }
            amount++;
        }

        public double[,] GetDCT(double[,] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n)
            {
                dct = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0) ci = 1.0/Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < n; j++)
                    {
                        if (j == 0) cj = 1.0/Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += (v[k, l]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public double[,] GetDCT(byte[,] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n)
            {
                dct = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0) ci = 1.0 / Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < n; j++)
                    {
                        if (j == 0) cj = 1.0 / Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += ((double)v[k, l]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public double[,] GetDCT(byte[] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n*n*4)
            {
                dct = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0) ci = 1.0 / Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < n; j++)
                    {
                        if (j == 0) cj = 1.0 / Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += ((double)v[4*(k*n+l)]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public double[,] GetDCT8(double[,] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n)
            {
                dct = new double[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0) ci = 1.0 / Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 0) cj = 1.0 / Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += (v[k, l]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public double[,] GetDCT8(byte[,] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n)
            {
                dct = new double[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0) ci = 1.0 / Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 0) cj = 1.0 / Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += ((double)v[k, l]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public double[,] GetDCT8(byte[] v)
        {
            double ci = 1;
            double cj = 1;
            double ko = 2.0 / (n * 1.0);
            double summ = 0;
            if (v.GetLength(0) == n * n*4)
            {
                dct = new double[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0) ci = 1.0 / Math.Sqrt(2); else ci = 1;
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 0) cj = 1.0 / Math.Sqrt(2); else cj = 1;
                        summ = 0;
                        for (int k = 0; k < n; k++)
                        {
                            for (int l = 0; l < n; l++)
                            {
                                summ += ((double)v[4*(k*n+l)]-128.0) * cos[i, k] * cos[j, l];
                            }
                        }
                        dct[i, j] = Math.Round(ko * ci * cj * summ);
                    }
                }
                return dct;
            }
            else return null;
        }

        public static double[,] MMnxn(double[,] a, double[,] b)
        {
            int ai = a.GetLength(0);
            int aj = a.GetLength(1);
            double[,] o = new double[ai, aj];
            for (int i = 0; i < ai; i++)
            {
                for (int j = 0; j < aj; j++)
                {
                    for (int k = 0; k < ai; k++)
                    {
                        o[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return o;
        }

        public Bitmap DCTtoBITMAP()
        {
            byte[] data = new byte[dct.GetLength(0) * dct.GetLength(1) * 4];
            int w = dct.GetLength(1);
            int h = dct.GetLength(0);
            Bitmap btmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    data[i * w * 4 + j * 4] = (byte)(Math.Abs(dct[i, j] + 128));
                    data[i * w * 4 + (j * 4 + 1)] = (byte)(Math.Abs(dct[i, j]+128));
                    data[i * w * 4 + (j * 4 + 2)] = (byte)(Math.Abs(dct[i, j]+128));
                    data[i * w * 4 + (j * 4 + 3)] = (byte)255;
                }
            }
            btmp = Sprite.ByteArrayToBitmap(data, w, h);
            return btmp;
        }

        public Bitmap BitDCTtoBITMAP()
        {
            byte[] data = new byte[bitDct.GetLength(0) * bitDct.GetLength(1) * 4];
            int w = bitDct.GetLength(1);
            int h = bitDct.GetLength(0);
            Bitmap btmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte col = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (bitDct[i, j] > 0) col = 255; else col = 0;
                    data[i * w * 4 + j * 4] = col;
                    data[i * w * 4 + (j * 4 + 1)] = col;
                    data[i * w * 4 + (j * 4 + 2)] = col;
                    data[i * w * 4 + (j * 4 + 3)] = (byte)255;
                }
            }
            btmp = Sprite.ByteArrayToBitmap(data, w, h);
            return btmp;
        }

        public UInt64 DCTtoInt64()
        {
            if (dct.GetLength(0) >= 8 && dct.GetLength(1) >= 8)
            {
                double middle = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                       if (i!=0 || j!=0) middle += dct[i, j];
                    }
                }
                middle = middle / 63.0;
                UInt64 hash = 0;
                bitDct = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i != 0 || j != 0)
                        if (dct[i, j] > middle) { 
                            hash = hash | ((ulong)1 << (i * 8 + j)); 
                            bitDct[i, j] = 1; 
                        }
                    }
                }
                return (UInt64)hash;
            }
            return 0;
        }

        public PictureBox GetPicture(int x = 0, int y = 0)
        {
            if (dct != null)
            {
                Bitmap b = DCTtoBITMAP();
                PictureBox pb = new PictureBox();
                pb.Size = new Size(b.Width, b.Height);
                pb.Location = new Point(x, y);
                pb.Name = "dct" + amount;
                pb.Image = b;
                return pb;
            }
            return null;
        }

        public PictureBox GetHashPicture(int x = 0, int y = 0)
        {
            if (bitDct != null)
            {
                Bitmap b = BitDCTtoBITMAP();
                PictureBox pb = new PictureBox();
                pb.Size = new Size(b.Width * 4, b.Height * 4);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Location = new Point(x, y);
                pb.Name = "dct" + amount;
                pb.Image = b;
                return pb;
            }
            return null;
        }
    }
}
