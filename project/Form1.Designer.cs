﻿
namespace project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetImage = new System.Windows.Forms.Button();
            this.chooseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonRGB = new System.Windows.Forms.Button();
            this.buttonHSV = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetImage
            // 
            this.buttonGetImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGetImage.Location = new System.Drawing.Point(67, 32);
            this.buttonGetImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGetImage.Name = "buttonGetImage";
            this.buttonGetImage.Size = new System.Drawing.Size(167, 42);
            this.buttonGetImage.TabIndex = 0;
            this.buttonGetImage.Text = "Загрузить фото4ку";
            this.buttonGetImage.UseVisualStyleBackColor = true;
            this.buttonGetImage.Click += new System.EventHandler(this.buttonGetImage_Click);
            // 
            // chooseFileDialog
            // 
            this.chooseFileDialog.Filter = "Картинки|*.jpeg;*.jpg";
            this.chooseFileDialog.InitialDirectory = "C:\\Users\\niko1\\Desktop\\images";
            // 
            // buttonGray
            // 
            this.buttonGray.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGray.Enabled = false;
            this.buttonGray.Location = new System.Drawing.Point(410, 32);
            this.buttonGray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(167, 42);
            this.buttonGray.TabIndex = 1;
            this.buttonGray.Text = "50 оттенков серого";
            this.buttonGray.UseVisualStyleBackColor = true;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // buttonRGB
            // 
            this.buttonRGB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRGB.Enabled = false;
            this.buttonRGB.Location = new System.Drawing.Point(238, 32);
            this.buttonRGB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRGB.Name = "buttonRGB";
            this.buttonRGB.Size = new System.Drawing.Size(167, 42);
            this.buttonRGB.TabIndex = 2;
            this.buttonRGB.Text = "Выделить каналы";
            this.buttonRGB.UseVisualStyleBackColor = true;
            this.buttonRGB.Click += new System.EventHandler(this.buttonRGB_Click);
            // 
            // buttonHSV
            // 
            this.buttonHSV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonHSV.Enabled = false;
            this.buttonHSV.Location = new System.Drawing.Point(582, 32);
            this.buttonHSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHSV.Name = "buttonHSV";
            this.buttonHSV.Size = new System.Drawing.Size(167, 42);
            this.buttonHSV.TabIndex = 3;
            this.buttonHSV.Text = "Перевести в HSV";
            this.buttonHSV.UseVisualStyleBackColor = true;
            this.buttonHSV.Click += new System.EventHandler(this.buttonHSV_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(815, 537);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(815, 537);
            this.Controls.Add(this.buttonHSV);
            this.Controls.Add(this.buttonRGB);
            this.Controls.Add(this.buttonGray);
            this.Controls.Add(this.buttonGetImage);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Основы основ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetImage;
        private System.Windows.Forms.OpenFileDialog chooseFileDialog;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.Button buttonRGB;
        private System.Windows.Forms.Button buttonHSV;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

