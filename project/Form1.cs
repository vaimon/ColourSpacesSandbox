﻿using System;
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
    public partial class Form1 : Form
    {
        string currentFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetImage_Click(object sender, EventArgs e)
        {
            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
                pictureBox.Load(currentFileName);
                buttonGray.Enabled = true;
                buttonHSV.Enabled = true;
                buttonRGB.Enabled = true;
            }
        }

        private void buttonRGB_Click(object sender, EventArgs e)
        {
            FormRGB form = new FormRGB(currentFileName);
            form.ShowDialog();
        }

        private void buttonGray_Click(object sender, EventArgs e)
        {
            FormGray form = new FormGray(currentFileName);
            
            form.ShowDialog();
        }

        private void buttonHSV_Click(object sender, EventArgs e)
        {
            FormHSV form = new FormHSV(currentFileName);
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
