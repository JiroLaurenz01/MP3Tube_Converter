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
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.loadingPercent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.statusLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            // progressBar
            // 
            this.progressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.progressBar.BorderRadius = 8;
            this.progressBar.BorderThickness = 2;
            this.progressBar.Location = new System.Drawing.Point(64, 74);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.SteelBlue;
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(153)))), ((int)(((byte)(230)))));
            this.progressBar.Size = new System.Drawing.Size(675, 30);
            this.progressBar.TabIndex = 9;
            this.progressBar.Text = "guna2ProgressBar1";
            this.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
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
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.statusLabel.Location = new System.Drawing.Point(327, 17);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(146, 31);
            this.statusLabel.TabIndex = 13;
            this.statusLabel.Text = "CONVERTING";
            // 
            // ConvertMP3Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.loadingPercent);
            this.Controls.Add(this.progressBar);
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
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel loadingPercent;
        private Guna.UI2.WinForms.Guna2HtmlLabel statusLabel;
    }
}
