namespace MP3_YoutubeConverter
{
    partial class ConvertMP3Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.loadingPercent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.browseBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.BorderRadius = 5;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.backBtn.FillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.backBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.backBtn.ForeColor = System.Drawing.Color.SteelBlue;
            this.backBtn.Location = new System.Drawing.Point(2, 1);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(67, 35);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "Back";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.guna2ProgressBar1.BorderRadius = 8;
            this.guna2ProgressBar1.BorderThickness = 2;
            this.guna2ProgressBar1.Location = new System.Drawing.Point(64, 74);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressColor = System.Drawing.Color.SteelBlue;
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.guna2ProgressBar1.Size = new System.Drawing.Size(675, 30);
            this.guna2ProgressBar1.TabIndex = 9;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // loadingPercent
            // 
            this.loadingPercent.BackColor = System.Drawing.Color.Transparent;
            this.loadingPercent.Enabled = false;
            this.loadingPercent.Font = new System.Drawing.Font("Bahnschrift Light", 16F);
            this.loadingPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.loadingPercent.Location = new System.Drawing.Point(64, 45);
            this.loadingPercent.Name = "loadingPercent";
            this.loadingPercent.Size = new System.Drawing.Size(35, 27);
            this.loadingPercent.TabIndex = 11;
            this.loadingPercent.Text = "0 %";
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.Color.Transparent;
            this.browseBtn.BorderRadius = 8;
            this.browseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.browseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.browseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.browseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.browseBtn.Enabled = false;
            this.browseBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.browseBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBtn.ForeColor = System.Drawing.Color.White;
            this.browseBtn.Location = new System.Drawing.Point(637, 45);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(102, 27);
            this.browseBtn.TabIndex = 12;
            this.browseBtn.Text = "Download";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(315, 17);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(172, 31);
            this.guna2HtmlLabel1.TabIndex = 13;
            this.guna2HtmlLabel1.Text = "DOWNLOADING";
            // 
            // ConvertMP3Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.loadingPercent);
            this.Controls.Add(this.guna2ProgressBar1);
            this.Controls.Add(this.backBtn);
            this.Name = "ConvertMP3Control";
            this.Size = new System.Drawing.Size(803, 118);
            this.Load += new System.EventHandler(this.ConvertMP3Control_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button backBtn;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2HtmlLabel loadingPercent;
        private Guna.UI2.WinForms.Guna2Button browseBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
