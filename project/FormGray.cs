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
        static int coef=0;
        public FormGray(string imagePath)
        {
            this.imagePath = imagePath;
            //this.Text = "50 оттенков серого";
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        static byte bytify(double color)
        {
            return (byte)((255/100 )* color);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            coef = (int)comboBox1.SelectedItem;//считываем коэффициент для разности полутоновых изображений
            
        }
        static Bitmap GoToGrey(Bitmap input,int flag)//flag- номер применяемой формулы
        {
            Bitmap res = new Bitmap(input.Width, input.Height);
            double r, g, b;
            using (var fbitmap = new FastBitmap(input))//битмап по исходной картинке
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j)); // FastBitmap для чтения текущего пикселя
                        if (flag == 1)
                        {// Y'=0.299R+0.587G+0.114B первая формула
                             r = (color.R * 0.299);
                             g = (color.G * 0.587);
                             b = (color.B * 0.114);
                            // gray = (byte)(r + g + b);
                        }
                        else 
                        {
                            //Y'=0.2126R+0.7152G+0.0722B вторая формула
                            r = (color.R * 0.2126);
                            g = (color.G * 0.7152);
                            b = (color.B * 0.0722);
                            
                        }
                        int gray = (int)(r + g + b);//считаем значение цвета
                        if (gray > 255)
                            gray = 255;
                        res.SetPixel(i, j, Color.FromArgb(gray,gray,gray));
                    }
                }
            }
            return res;
            }
        
        static Bitmap GetDifference(Bitmap input1,Bitmap input2,int c)
        {
            Bitmap res = new Bitmap(input1.Width, input1.Height);
            
            int a,r, g, b,col;
            var fbitmap2 = new FastBitmap(input2);// FastBitmap для чтения текущего пикселя
            using (var fbitmap1 = new FastBitmap(input1))
            {
                for (int i = 0; i < fbitmap1.Width; i++)
                {
                    for (int j = 0; j < fbitmap1.Height; j++)
                    {
                        Color color1 = fbitmap1.GetPixel(new Point(i, j)); 
                        Color color2 = fbitmap2.GetPixel(new Point(i, j));

                           // a = Math.Abs( color2.A - color1.A);
                            r = Math.Abs(color2.R -color1.R);//Находим разницу, значение интенсивности в каждом цвете тут одинаковое,
                                                             //поэтому не так важно, какой цвет брать
                           // g = Math.Abs(color2.G -color1.G);
                            //b = Math.Abs(color2.B -color1.B);

                        if (r * c > 255)//коэффициент считывается из combobox, проверка, что с ним мы не выйдем за 255
                             col = 255;
                        else
                            col = r * c;

                        
                        res.SetPixel(i, j, Color.FromArgb(col,col,col));//закрашиваем пиксель
                    }
                }
            }
            return res;
        }
        static Bitmap Hist(Bitmap input)//рисуем гистограмму
        {
            Dictionary<int, int> intense = new Dictionary<int, int>();//словарь
            //ключ- интенсивность пикселя
            //значение- количество пикселей данной интенсивности
            Bitmap res = new Bitmap(input.Width, input.Height);
            for (int i = 0; i < 256; i++)
            {
                intense.Add(i, 0);//просто инициализируем и пока значения ключей пустые
            }
            using (var fbitmap = new FastBitmap(input))
            {
                for (int i = 0; i < fbitmap.Width; i++)
                {
                    for (int j = 0; j < fbitmap.Height; j++)
                    {
                        Color color = fbitmap.GetPixel(new Point(i, j)); //считываем пиксель, т к у нас полутоновое изображение,
                                                                         //тут все цвета будут иметь одинаковую насыщенность,
                                                                         //все равно, по какому будем считать
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
            for (int i = 0; i < 256; i++)//находим максимум пикселей интенсивности
            {
                if (intense[i] > max)
                    max = intense[i];
            }
            double scale = ((double)max )/ 256;//это для масштаба, вдруг у нас 1000000 пикселей этой интенсивности

            for (int i = 0; i < 256; ++i)//по абсциссам 0..255
            {
                for (int j = input.Height-1; j > 256 - intense[i] / scale; --j)//по ординатам закрашиваем нужное количество пикселей
                                                                               //данной интенсивности
                    res.SetPixel(i, j, Color.DarkGray);

                
            }
            return res;
        }
        private void FormGray_Load(object sender, EventArgs e)//открываем исходную картиночку 
        {
            pictureBox.Load(imagePath);
            
        }

        private void button1_Click(object sender, EventArgs e)//событие-при нажатии на кнопку запускаем перевод в серый по 1 формуле
        {
            Image newImage = Image.FromFile(imagePath);
            var bitmap = new Bitmap(newImage);
            var res= GoToGrey(bitmap,1);
            pictureBox1.Image=res;
            //res.Save("1", System.Drawing.Imaging.ImageFormat.Jpeg);

        }
        private void button2_Click(object sender, EventArgs e)//перевод в серый по второй формуле
        {
            Image newImage = Image.FromFile(imagePath);
            var bitmap = new Bitmap(newImage);
            var res = GoToGrey(bitmap, 2);
            pictureBox2.Image = res;

        }

        private void button3_Click(object sender, EventArgs e)//смотрим разницу
        {
            //Image newImage = Image.FromFile(imagePath);
            var bitmap1 = new Bitmap(pictureBox1.Image);
            var bitmap2 = new Bitmap(pictureBox2.Image);
            
            var res = GetDifference(bitmap1,bitmap2,coef);
            pictureBox3.Image = res;
        }

        private void button4_Click(object sender, EventArgs e)//рисуем гистограмму для 1 полутонового изображения
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            var res = Hist(bitmap);
            pictureBox4.Image = res;
        }

        private void button5_Click(object sender, EventArgs e)//рисуем гистограмму для 2 полутонового изображения
        {
            var bitmap = new Bitmap(pictureBox2.Image);
            var res = Hist(bitmap);
            pictureBox5.Image = res;
            
        }
    }
}
