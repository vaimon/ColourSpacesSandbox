
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownHue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSaturation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
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
            // numericUpDownHue
            // 
            this.numericUpDownHue.Location = new System.Drawing.Point(657, 127);
            this.numericUpDownHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownHue.Name = "numericUpDownHue";
            this.numericUpDownHue.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownHue.TabIndex = 6;
            this.numericUpDownHue.ValueChanged += new System.EventHandler(this.numericUpDownHue_ValueChanged);
            // 
            // numericUpDownSaturation
            // 
            this.numericUpDownSaturation.DecimalPlaces = 1;
            this.numericUpDownSaturation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSaturation.Location = new System.Drawing.Point(657, 266);
            this.numericUpDownSaturation.Name = "numericUpDownSaturation";
            this.numericUpDownSaturation.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownSaturation.TabIndex = 7;
            this.numericUpDownSaturation.ValueChanged += new System.EventHandler(this.numericUpDownSaturation_ValueChanged);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.DecimalPlaces = 1;
            this.numericUpDownValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownValue.Location = new System.Drawing.Point(657, 398);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(180, 31);
            this.numericUpDownValue.TabIndex = 8;
            this.numericUpDownValue.ValueChanged += new System.EventHandler(this.numericUpDownValue_ValueChanged);
            // 
            // FormHSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.numericUpDownSaturation);
            this.Controls.Add(this.numericUpDownHue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormHSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конвертация в HSV";
            this.Load += new System.EventHandler(this.FormHSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownHue;
        private System.Windows.Forms.NumericUpDown numericUpDownSaturation;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
    }
}