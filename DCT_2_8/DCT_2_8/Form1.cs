using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using DCT_2;

namespace DCT_2_8
{
    public partial class Form1 : Form
    {
        public static int xcur = 0;
        public static int ycur = 0;

        Picture p1;
        Picture p2;
        Picture p3;
        Picture p4;
        Picture p5;
        Picture p6;
        Picture p7;
        Picture p8;
        
        public Form1()
        {
            InitializeComponent();
            Go();
        }

        void Go()
        {
            p1 = new Picture("Blue.bmp");
            Point point = p1.GetPictures(splitContainer1.Panel1.Controls, 0,0);
            p2 = new Picture("Green.bmp");
            point = p2.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p3 = new Picture("Red.bmp");
            point = p3.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p4 = new Picture("Yellow.bmp");
            point = p4.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p5 = new Picture("Cyan.bmp");
            point = p5.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p6 = new Picture("Magenta.bmp");
            point = p6.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p7 = new Picture("five.bmp");
            point = p7.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);
            p8 = new Picture("three.bmp");
            point = p8.GetPictures(splitContainer1.Panel1.Controls, 0, point.Y);

            List<string> inf = new List<string>();
            inf.Add("Перая картинка отличается от второй на " + Picture.Distance(p1,p2));
            inf.Add("Перая картинка отличается от третьей на " + Picture.Distance(p1, p3));
            inf.Add("Перая картинка отличается от четвертой на " + Picture.Distance(p1, p4));
            inf.Add("Перая картинка отличается от пятой на " + Picture.Distance(p1, p5));
            inf.Add("Перая картинка отличается от шестой на " + Picture.Distance(p1, p6));
            inf.Add("Перая картинка отличается от 7 на " + Picture.Distance(p1, p7));
            inf.Add("Перая картинка отличается от 8 на " + Picture.Distance(p1, p8));

            inf.Add("Вторая картинка отличается от третьей на " + Picture.Distance(p2, p3));
            inf.Add("Вторая картинка отличается от четвертой на " + Picture.Distance(p2, p4));
            inf.Add("Вторая картинка отличается от пятой на " + Picture.Distance(p2, p5));
            inf.Add("Вторая картинка отличается от шестой на " + Picture.Distance(p2, p6));
            inf.Add("Вторая картинка отличается от 7 на " + Picture.Distance(p2, p7));
            inf.Add("Вторая картинка отличается от 8 на " + Picture.Distance(p2, p8));

            inf.Add("Третья картинка отличается от четвертой на " + Picture.Distance(p3, p4));
            inf.Add("Третья картинка отличается от пятой на " + Picture.Distance(p3, p5));
            inf.Add("Третья картинка отличается от шестой на " + Picture.Distance(p3, p6));
            inf.Add("Третья картинка отличается от 7 на " + Picture.Distance(p3, p7));
            inf.Add("Третья картинка отличается от 8 на " + Picture.Distance(p3, p8));

            inf.Add("Четвертая картинка отличается от пятой на " + Picture.Distance(p4, p5));
            inf.Add("Четвертая картинка отличается от шестой на " + Picture.Distance(p4, p6));
            inf.Add("Четвертая картинка отличается от 7 на " + Picture.Distance(p4, p7));
            inf.Add("Четвертая картинка отличается от 8 на " + Picture.Distance(p4, p8));

            inf.Add("Пятая картинка отличается от шестой на " + Picture.Distance(p5, p6));
            inf.Add("Пятая картинка отличается от 7 на " + Picture.Distance(p5, p7));
            inf.Add("Пятая картинка отличается от 8 на " + Picture.Distance(p5, p8));

            inf.Add("6 картинка отличается от 7 на " + Picture.Distance(p6, p7));
            inf.Add("6 картинка отличается от 8 на " + Picture.Distance(p6, p8));

            inf.Add("7 картинка отличается от 8 на " + Picture.Distance(p7, p8));

            textBox1.Lines = inf.ToArray();
        }
    }
}
