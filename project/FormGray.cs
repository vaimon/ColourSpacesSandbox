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
        public FormGray(string imagePath)
        {
            this.imagePath = imagePath;
            InitializeComponent();
        }

        private void FormGray_Load(object sender, EventArgs e)
        {
            pictureBox.Load(imagePath);
        }
    }
}
