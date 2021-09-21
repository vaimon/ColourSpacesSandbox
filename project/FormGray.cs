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
    public partial class FormGray : Form
    {
        string imagePath;
       // Bitmap bitmap;
        static int max = 0;
        public FormGray(string imagePath)
        {
            this.imagePath = imagePath;
            //this.Text = "50 оттенков серого";
            InitializeComponent();
        }
        static byte bytify(double color)
        {
            return (byte)((255/100 )* color);
        }
        static Bitmap GoToGrey(Bitmap input,int flag)
        {
            Bitmap res = new Bitmap(input.Width, input.Height);
            double r, g, b;
            using (var fbitmap = new FastBitmap(input))
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j)); // FastBitmap для чтения текущего пикселя
                        if (flag == 1)
                        {// Y'=0.299R+0.587G+0.114B
                             r = (color.R * 0.299);
                             g = (color.G * 0.587);
                             b = (color.B * 0.114);
                            // gray = (byte)(r + g + b);
                        }
                        else 
                        {
                            //Y'=0.2126R+0.7152G+0.0722B
                            r = (color.R * 0.2126);
                            g = (color.G * 0.7152);
                            b = (color.B * 0.0722);
                            
                        }
                        int gray = (int)(r + g + b);
                        if (gray > 255)
                            gray = 255;
                        res.SetPixel(i, j, Color.FromArgb(gray,gray,gray));
                    }
                }
            }
            return res;
            }
        
        static Bitmap GetDifference(Bitmap input1,Bitmap input2)
        {
            Bitmap res = new Bitmap(input1.Width, input1.Height);
            int a,r, g, b;
            var fbitmap2 = new FastBitmap(input2);
            using (var fbitmap1 = new FastBitmap(input1))
            {
                for (int i = 0; i < fbitmap1.Width; i++)
                {
                    for (int j = 0; j < fbitmap1.Height; j++)
                    {
                        Color color1 = fbitmap1.GetPixel(new Point(i, j)); // FastBitmap для чтения текущего пикселя
                        Color color2 = fbitmap2.GetPixel(new Point(i, j));

                            a = Math.Abs( color2.A - color1.A);
                            r = Math.Abs(color2.R -color1.R);
                            g = Math.Abs(color2.G -color1.G);
                            b = Math.Abs(color2.B -color1.B);

                        
                        
                        res.SetPixel(i, j, Color.FromArgb( r, r, r));
                    }
                }
            }
            return res;
        }
        static Bitmap Hist(Bitmap input)
        {
            Dictionary<int, int> intense = new Dictionary<int, int>();
            Bitmap res = new Bitmap(input.Width, input.Height);
            for (int i = 0; i < 256; i++)
            {
                intense.Add(i, 0);
            }
            using (var fbitmap = new FastBitmap(input))
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j)); // FastBitmap для чтения текущего пикселя
                        //int x = color.R;
                           
                        if (intense.ContainsKey(color.R))
                            intense[color.R]++;
                        // else
                        //  intense.Add(color.R, 1);
                        else
                        
                            if (intense.ContainsKey(color.G))
                                intense[color.G]++;
                           //  else
                           // intense.Add(color.G, 1);
                        
                        else
                        {
                            if (intense.ContainsKey(color.B))
                                intense[color.B]++;
                          //  else
                            //intense.Add(color.B, 1);
                        }
                        // else
                        // intense.Add(color.B, 1);




                    }
                }
            }
            for (int i = 0; i < 256; i++)
            {
                if (intense[i] > max)
                    max = intense[i];
            }
            double point = (double)max / 256;

            for (int i = 0; i < 256; ++i)
            {
                for (int j = input.Height-1; j > 256 - intense[i] / point; --j)
                    res.SetPixel(i, j, Color.DarkGray);

                
            }
            return res;
        }
        private void FormGray_Load(object sender, EventArgs e)
        {
            pictureBox.Load(imagePath);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image newImage = Image.FromFile(imagePath);
            var bitmap = new Bitmap(newImage);
            var res= GoToGrey(bitmap,1);
            pictureBox1.Image=res;
            //res.Save("1", System.Drawing.Imaging.ImageFormat.Jpeg);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Image newImage = Image.FromFile(imagePath);
            var bitmap = new Bitmap(newImage);
            var res = GoToGrey(bitmap, 2);
            pictureBox2.Image = res;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Image newImage = Image.FromFile(imagePath);
            var bitmap1 = new Bitmap(pictureBox1.Image);
            var bitmap2 = new Bitmap(pictureBox2.Image);
            var res = GetDifference(bitmap1,bitmap2);
            pictureBox3.Image = res;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            var res = Hist(bitmap);
            pictureBox4.Image = res;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox2.Image);
            var res = Hist(bitmap);
            pictureBox5.Image = res;
            
        }
    }
}
