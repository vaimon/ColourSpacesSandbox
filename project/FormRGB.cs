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
    public partial class FormRGB : Form
    {
        string imagePath;
        Bitmap bitmap;

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

        //полуфаст
        static Bitmap[] GetRgbChannels(Bitmap bm)
        {
            //Bitmap temp = new Bitmap(bm.Width, bm.Height);
            //Bitmap redBitmap = new Bitmap(bm.Width, bm.Height), greenBitmap = new Bitmap(bm.Width, bm.Height), blueBitmap = new Bitmap(bm.Width, bm.Height);
            //FastBitmap redFBM = new FastBitmap(redBitmap), greenFBM = new FastBitmap(greenBitmap), blueFBM = new FastBitmap(blueBitmap);
            //FastBitmap redFBM = new FastBitmap(temp), greenFBM = new FastBitmap(temp), blueFBM = new FastBitmap(temp);
            Bitmap[] result = new Bitmap[3] { new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height) };
            using (var fbitmap = new FastBitmap(bm))
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j));
                        //Color color = bm.GetPixel(i, j);

                        //result[0].SetPixel(new Point(i, j), Color.FromArgb(color.A, color.R, 0, 0));
                        //result[1].SetPixel(new Point(i, j), Color.FromArgb(color.A, 0, color.G, 0));
                        //result[2].SetPixel(new Point(i, j), Color.FromArgb(color.A, 0, 0, color.B));
                        result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                        result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                        result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));
                    }
                }
            }
            return result;
        }

        /*        static FastBitmap[] GetRgbChannels(FastBitmap bm)
                {
                    Bitmap temp = new Bitmap(bm.Width, bm.Height);
                    //Bitmap redBitmap = new Bitmap(bm.Width, bm.Height), greenBitmap = new Bitmap(bm.Width, bm.Height), blueBitmap = new Bitmap(bm.Width, bm.Height);
                    //FastBitmap redFBM = new FastBitmap(redBitmap), greenFBM = new FastBitmap(greenBitmap), blueFBM = new FastBitmap(blueBitmap);
                    FastBitmap redFBM = new FastBitmap(temp), greenFBM = new FastBitmap(temp), blueFBM = new FastBitmap(temp);
                    //Bitmap[] result = new Bitmap[3] { new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height) };
                    FastBitmap[] result = new FastBitmap[3] { redFBM, greenFBM, blueFBM };

                    for (int i = 0; i < bm.Width; i++)
                    {
                        for (int j = 0; j < bm.Height; j++)
                        {
                            Color color = bm.GetPixel(new Point(i, j));
                            //Color color = bm.GetPixel(i, j);

                            result[0].SetPixel(new Point(i, j), Color.FromArgb(color.A, color.R, 0, 0));
                            result[1].SetPixel(new Point(i, j), Color.FromArgb(color.A, 0, color.G, 0));
                            result[2].SetPixel(new Point(i, j), Color.FromArgb(color.A, 0, 0, color.B));
                            //result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                            //result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                            //result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));
                        }
                    }

                    return result;
                }*/

        public FormRGB(string imagePath)
        {
            this.imagePath = imagePath;
            InitializeComponent();
        }

        private void FormRGB_Load(object sender, EventArgs e)
        {
            pictureBox.Load(imagePath);
            //pictureBox1.Load(imagePath);
            //pictureBox2.Load(imagePath);
            //pictureBox3.Load(imagePath);

            Image newImage = Image.FromFile(imagePath);
            bitmap = new Bitmap(newImage);
            //Bitmap[] res;           
            //Bitmap[] res = new Bitmap[3] { new Bitmap(bitmap.Width, bitmap.Height), new Bitmap(bitmap.Width, bitmap.Height), new Bitmap(bitmap.Width, bitmap.Height) };

            var res = GetRgbChannels(bitmap);

            pictureBox1.Image = res[0];
            pictureBox2.Image = res[1];
            pictureBox3.Image = res[2];

        }
    }
}