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
        //static int max = 0;
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
                        byte gray = (byte)(r + g + b);
                        res.SetPixel(i, j, Color.FromArgb(color.A,gray,gray,gray));
                    }
                }
            }
            return res;
            }
        
        static Bitmap GetDifference(Bitmap input1,Bitmap input2)
        {
            Bitmap res = new Bitmap(input1.Width, input1.Height);
            byte r, g, b;
            var fbitmap2 = new FastBitmap(input2);
            using (var fbitmap1 = new FastBitmap(input1))
            {
                for (int i = 0; i < fbitmap1.Width; i++)
                {
                    for (int j = 0; j < fbitmap1.Height; j++)
                    {
                        Color color1 = fbitmap1.GetPixel(new Point(i, j)); // FastBitmap для чтения текущего пикселя
                        Color color2 = fbitmap1.GetPixel(new Point(i, j));
                       
                        {
                            r = (byte)(Math.Abs(color2.R -color1.R)+0.3819 * 255);
                            g = (byte)(Math.Abs(color2.G - color1.G) + 0.3819 * 255);//Math.Abs(color2.G -color1.G);
                            b = (byte)(Math.Abs(color2.B - color1.B) + 0.3819 * 255);//Math.Abs(color2.B -color1.B);

                        }
                        
                        res.SetPixel(i, j, Color.FromArgb(color1.A, r, g, b));
                    }
                }
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
    }
}
