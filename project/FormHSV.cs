using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormHSV : Form
    {
        private class HSV
        {
            public double hue;
            public double saturation;
            public double value;

            public HSV(double hue, double saturation, double value)
            {
                this.hue = hue;
                this.saturation = saturation;
                this.value = value;
            }
        }

        private class RGB
        {
            public byte r, g, b;

            public RGB(byte r, byte g, byte b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        string imagePath;
        Bitmap bitmap;
        public FormHSV(string imagePath)
        {
            this.imagePath = imagePath;
            InitializeComponent();
        }

        private HSV RGBtoHSV(double R, double G, double B)
        {
            double h = 0, s;
            double max = Math.Max(Math.Max(R, G),B);
            double min = Math.Min(Math.Min(R, G), B);
            if((max == R) && (G>=B)) {
                h = 60 * ((G - B) / (max - min));
            } else if((max == R) && (G < B))
            {
                h = 60 * ((G - B) / (max - min)) + 360;
            } else if(max == G)
            {
                h = 60 * ((B - R) / (max - min)) + 120;
            } else if (max == B)
            {
                h = 60 * ((R - G) / (max - min)) + 240;
            }

            s = max == 0 ? 0 : (1 - (min / max));

            return new HSV(h, s*100, max*100);
        }
        private byte bytify (double color)
        {
            return (byte)((255 / 100) * color);
        }
        private RGB HSVtoRGB(double hue, double saturation, double value)
        {
            int sw = (int)Math.Floor(hue / 60) % 6;
            double vmin = ((100 - saturation) * value) / 100;
            double a = (value - vmin) * ((hue % 60) / 60);
            double vinc = vmin + a;
            double vdec = value - a;
            switch (sw)
            {
                case 0: return new RGB(bytify(value), bytify(vinc), bytify(vmin));
                case 1: return new RGB(bytify(vdec), bytify(value), bytify(vmin));
                case 2: return new RGB(bytify(vmin), bytify(value), bytify(vinc));
                case 3: return new RGB(bytify(vmin), bytify(vdec), bytify(value));
                case 4: return new RGB(bytify(vinc), bytify(vmin), bytify(value));
                case 5: return new RGB(bytify(value), bytify(vmin), bytify(vdec));
            }
            return new RGB(0, 0, 0);
        }

        private void FormHSV_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(imagePath);
            for(int x = 0; x < bitmap.Size.Width; x++)
            {
                for(int y = 0; y < bitmap.Size.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x,y);
                    var hsv = RGBtoHSV(pixel.R / 256, pixel.G / 256, pixel.B / 256);
                }
            }
            
            pictureBox.Image = bitmap;
        }
    }
}
