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
        public FormRGB(string imagePath)
        {
            this.imagePath = imagePath;
            InitializeComponent();
        }

        private void FormRGB_Load(object sender, EventArgs e)
        {
            pictureBox.Load(imagePath);
        }
    }
}
