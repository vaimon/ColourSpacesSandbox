
namespace project
{
    partial class FormHSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.trackBarValue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(596, 543);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // trackBarHue
            // 
            this.trackBarHue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarHue.LargeChange = 1;
            this.trackBarHue.Location = new System.Drawing.Point(630, 113);
            this.trackBarHue.Maximum = 100;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(229, 69);
            this.trackBarHue.TabIndex = 1;
            this.trackBarHue.TabStop = false;
            this.trackBarHue.TickFrequency = 10;
            this.trackBarHue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarHue.ValueChanged += new System.EventHandler(this.trackBarHue_ValueChanged);
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSaturation.LargeChange = 1;
            this.trackBarSaturation.Location = new System.Drawing.Point(630, 250);
            this.trackBarSaturation.Maximum = 100;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(229, 69);
            this.trackBarSaturation.TabIndex = 2;
            this.trackBarSaturation.TickFrequency = 10;
            this.trackBarSaturation.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSaturation.ValueChanged += new System.EventHandler(this.trackBarSaturation_ValueChanged);
            // 
            // trackBarValue
            // 
            this.trackBarValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarValue.LargeChange = 1;
            this.trackBarValue.Location = new System.Drawing.Point(630, 384);
            this.trackBarValue.Maximum = 100;
            this.trackBarValue.Name = "trackBarValue";
            this.trackBarValue.Size = new System.Drawing.Size(229, 69);
            this.trackBarValue.TabIndex = 3;
            this.trackBarValue.TickFrequency = 10;
            this.trackBarValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarValue.ValueChanged += new System.EventHandler(this.trackBarValue_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(630, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hue | Тон";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(630, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Saturation | Насыщенность";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(630, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value | Значение";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormHSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarValue);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormHSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конвертация в HSV";
            this.Load += new System.EventHandler(this.FormHSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.TrackBar trackBarValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}