using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCT_2
{
    public class Sprite
    {
        static int amount = 0;
        Image source;
        Image img;
        Bitmap btm;

        byte[] btmData;
        //byte[,] btmDataSq;

        public byte[] LineData { get { return btmData; } }
        //public byte[,] SquareDate { get { return btmDataSq; } }
        public Image SourceImage { get { return source; } }
        public Image ScaledImage { get { return img; } }
        public Image GrayImage { get { return btm; } }

        public Sprite(String path)
        {
            source = Image.FromFile(path);
            img = ScaleImage(source, 32, 32);
            btm = MakeGray(new Bitmap(img));
            btmData = BitmapToByteArray(btm);
            //btmDataSq = new byte[btm.Height, btm.Width];
            //btmData.CopyTo(btmDataSq, 0);
            amount++;
            /*for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    btmDataSq[i, j] = btmData[4*(i * img.Width + j)];
                }
            }*/
        }
        public Sprite(Image i)
        {
            source = i;
            img = ScaleImage(source, 32, 32);
            btm = MakeGray(new Bitmap(img));
            btmData = BitmapToByteArray(btm);
            //btmDataSq = new byte[btm.Height, btm.Width];
            //btmData.CopyTo(btmDataSq, 0);
            amount++;
            /*for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    btmDataSq[i, j] = btmData[4*(i * img.Width + j)];
                }
            }*/
        }

        public static Image ScaleImage(Image source, int width, int height)
        {

            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.Black, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }

        public static Bitmap MakeGray(Bitmap bmp1)
        {
            Bitmap bmp = (Bitmap)bmp1.Clone();
            // Задаём формат Пикселя.
            PixelFormat pxf = PixelFormat.Format24bppRgb;

            // Получаем данные картинки.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //Блокируем набор данных изображения в памяти
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Получаем адрес первой линии.
            IntPtr ptr = bmpData.Scan0;

            // Задаём массив из Byte и помещаем в него надор данных.
            // int numBytes = bmp.Width * bmp.Height * 3; 
            //На 3 умножаем - поскольку RGB цвет кодируется 3-мя байтами
            //Либо используем вместо Width - Stride
            int numBytes = bmpData.Stride * bmp.Height;
            int widthBytes = bmpData.Stride;
            byte[] rgbValues = new byte[numBytes];

            // Копируем значения в массив.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Перебираем пикселы по 3 байта на каждый и меняем значения
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {

                byte value = (byte)(0.299f*rgbValues[counter] + 0.587f*rgbValues[counter + 1] + 0.114f*rgbValues[counter + 2]);
                
                rgbValues[counter] = value;
                rgbValues[counter + 1] = value;
                rgbValues[counter + 2] = value;

            }
            // Копируем набор данных обратно в изображение
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Разблокируем набор данных изображения в памяти.
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {

            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }

        public static Bitmap ByteArrayToBitmap(byte[] b, int w, int h)
        {

            BitmapData bmpdata = null;
            Bitmap bitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                //byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(b, 0, ptr, b.Length);
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }
            return bitmap;
        }

        public PictureBox GetPicture(int x = 0, int y = 0, float s = 1.0f)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size((int)(source.Width * s), (int)(source.Height * s));
            pb.Location = new Point(x, y);
            pb.Name = "sp" + amount;
            pb.Image = source;
            return pb;
        }

        public PictureBox GetSmallPicture(int x = 0, int y = 0, float s = 1.0f)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size((int)(img.Width * s), (int)(img.Height * s));
            pb.Location = new Point(x, y);
            pb.Name = "mp" + amount;
            pb.Image = img;
            return pb;
        }

        public PictureBox GetGrayPicture(int x = 0, int y = 0, float s = 1.0f)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size((int)(btm.Width * s), (int)(btm.Height * s));
            pb.Location = new Point(x, y);
            pb.Name = "gp" + amount;
            pb.Image = btm;
            return pb;
        }
    }
}
