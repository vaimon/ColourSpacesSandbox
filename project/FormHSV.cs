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
        int averageHue;
        double averageSaturation;
        double averageValue;

        double currentHue;
        double currentSaturation;
        double currentValue;

        bool isLoaded = false;

        private class HSV
        {
            // 0-360
            public double hue;
            // 0-100
            public double saturation;
            // 0-100
            public double value;

            public HSV(double hue, double saturation, double value)
            {
                this.hue = Math.Round(hue,1);
                this.saturation = Math.Round(saturation * 100, 1);
                this.value = Math.Round(value * 100, 1);
            }

            public void add(double hue, double sat, double val)
            {
                if(this.hue + hue < 0)
                {
                    this.hue = 360 + this.hue - hue;
                }
                else
                {
                    this.hue = (this.hue + hue) % 360;
                }

                if(saturation + sat < 0)
                {
                    saturation = 0;
                } else if (saturation + sat > 100)
                {
                    saturation = 100;
                }
                else
                {
                    saturation += sat;
                }

                if (value + val < 0)
                {
                    value = 0;
                }
                else if (value + val > 100)
                {
                    value = 100;
                }
                else
                {
                    value += val;
                }

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

        private static HSV RGBtoHSV(byte red, byte green, byte blue)
        {
            double h = 0, s;
            byte max = Math.Max(Math.Max(red, green),blue);
            byte min = Math.Min(Math.Min(red, green), blue);
            s = 1.0 - (min * 1.0 / max);
            if (max == 0)
            {
                h = 0;
                s = 0;
            } else if(max == min)
            {
                h = 0;
            } else if((max == red) && (green>=blue)) {
                h = 60 * ((green - blue) / (max* 1.0 - min));
            } else if((max == red) && (green < blue))
            {
                h = 60 * ((green - blue) / (1.0 * max - min)) + 360;
            } else if(max == green)
            {
                h = 60 * ((blue - red) / (1.0 * max - min)) + 120;
            } else if (max == blue)
            {
                h = 60 * ((red - green) / (1.0 * max - min)) + 240;
            }

            return new HSV(h, s, max/255.0);
        }
        private byte bytify (double color)
        {
            return (byte)Math.Round((255 / 100.0) * color);
        }
        private RGB HSVtoRGB(double hue, double saturation, double value)
        {
            int sw = (int)Math.Floor(hue / 60) % 6;
            double vmin = ((100 - saturation) * value) / 100.0;
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
            using (var fbitmap = new FastBitmap(bitmap))
            {
                double hue = 0, saturation = 0, value = 0;
                for (int x = 0; x < fbitmap.Width; x++)
                {
                    for (int y = 0; y < fbitmap.Height; y++)
                    {
                        Color pixel = fbitmap.GetPixel(new Point(x, y));
                        var hsv = RGBtoHSV(pixel.R, pixel.G, pixel.B);
                        hue += hsv.hue;
                        saturation += Math.Round(hsv.saturation,1);
                        value += Math.Round(hsv.value, 1);
                    }
                }
                currentHue = averageHue = (int) (hue / fbitmap.Count);
                currentSaturation = averageSaturation = Math.Round(saturation / fbitmap.Count, 1);
                currentValue = averageValue = Math.Round(value / fbitmap.Count,1);
            }
            numericUpDownHue.Value = averageHue;
            numericUpDownSaturation.Value = (int)averageSaturation;
            numericUpDownValue.Value = (int)averageValue;
            pictureBox.Image = bitmap;
            isLoaded = true;
        }

        private void updateImage()
        {
            double hueShift = currentHue - averageHue;
            double satShift = currentSaturation - averageSaturation;
            double valShift = currentValue - averageValue;
            var nbitmap = bitmap.Clone() as Bitmap;
            using (var fbitmap = new FastBitmap(nbitmap))
            {
                for (int x = 0; x < fbitmap.Width; x++)
                {
                    for (int y = 0; y < fbitmap.Height; y++)
                    {
                        var point = new Point(x, y);
                        Color pixel = fbitmap.GetPixel(point);
                        var hsv = RGBtoHSV(pixel.R, pixel.G, pixel.B);
                        hsv.add(hueShift, satShift, valShift);
                        var rgb = HSVtoRGB(hsv.hue, hsv.saturation, hsv.value);
                        fbitmap.SetPixel(point, Color.FromArgb(rgb.r, rgb.g, rgb.b));
                    }
                }
            }
            pictureBox.Image = nbitmap;
        }

      


        private void numericUpDownValue_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }
            currentValue = (double)numericUpDownValue.Value;
            updateImage();
        }

        private void numericUpDownSaturation_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }
            currentSaturation = (double)numericUpDownSaturation.Value;
            updateImage();
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }
            currentHue = (double)numericUpDownHue.Value;
            updateImage();
           
        }
    }
}
