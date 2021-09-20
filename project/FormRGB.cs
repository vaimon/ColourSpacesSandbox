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
        static int max = 0;

        static SortedDictionary<int, int> redChanell = new SortedDictionary<int, int>();
        static SortedDictionary<int, int> greenChanell = new SortedDictionary<int, int>();
        static SortedDictionary<int, int> blueChanell = new SortedDictionary<int, int>();

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
       
        static Bitmap[] GetRgbChannels(Bitmap bm)
        {

            Bitmap[] result = new Bitmap[3] { new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height), new Bitmap(bm.Width, bm.Height) };
            using (var fbitmap = new FastBitmap(bm))
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j));

                        result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                        result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                        result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));

                        //подсчёт значений красного для гистограммы
                        if (redChanell.ContainsKey(color.R))
                            redChanell[color.R]++;
                        else
                            redChanell.Add(color.R, 1);

                        //подсчёт значений зеленого для гистограммы
                        if (greenChanell.ContainsKey(color.G))
                            greenChanell[color.G]++;
                        else
                            greenChanell.Add(color.G, 1);

                        //подсчёт значений синего для гистограммы
                        if (blueChanell.ContainsKey(color.B))
                            blueChanell[color.B]++;
                        else
                            blueChanell.Add(color.B, 1);
                    }
                }
            }
            return result;
        }

        public static Bitmap Histogram()
        {
            Bitmap res = new Bitmap(256, 256);

            var rkeys = redChanell.Keys;
            var gkeys = greenChanell.Keys;
            var bkeys = blueChanell.Keys;

            for (int i = 0; i < 256; i++)
            {
                if (!redChanell.ContainsKey(i))
                    redChanell[i] = 0;
                if (!greenChanell.ContainsKey(i))
                    greenChanell[i] = 0;
                if (!blueChanell.ContainsKey(i))
                    blueChanell[i] = 0;
            }

            for (int i = 0; i < 256; i++)
            {
                if (redChanell[i] > max)
                    max = redChanell[i];

                if (greenChanell[i] > max)
                    max = greenChanell[i];

                if (blueChanell[i] > max)
                    max = blueChanell[i];
            }
            
        
           
            double point = (double)max / 256;
            
            for (int i = 0; i < 256; ++i)
            {
                for (int j = 255; j > 256 - redChanell[i] / point; --j)                
                    res.SetPixel(i, j, Color.Red);
                
                for (int j = 255; j > 256 - greenChanell[i] / point; --j)                
                    res.SetPixel(i, j, Color.Green);
                
                for (int j  = 255; j > 256 - blueChanell[i] / point; --j)                
                    res.SetPixel(i, j, Color.Blue);               
            }

            return res;

        }

        public FormRGB(string imagePath)
        {
            this.imagePath = imagePath;
            InitializeComponent();
        }

        private void FormRGB_Load(object sender, EventArgs e)
        {
            pictureBox.Load(imagePath);

            Image newImage = Image.FromFile(imagePath);
            bitmap = new Bitmap(newImage);

            var res = GetRgbChannels(bitmap);

            pictureBox1.Image = res[0];
            pictureBox2.Image = res[1];
            pictureBox3.Image = res[2];
            
            pictureBox4.Image = Histogram();
            label8.Text = max.ToString();

        }
    }
}