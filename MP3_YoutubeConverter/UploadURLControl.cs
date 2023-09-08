using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3_YoutubeConverter
{
    public partial class UploadURLControl : UserControl
    {
        public UploadURLControl()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the MainForm if it exists.
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

            if (mainForm != null)
            {
                mainForm.Size = new Size(mainForm.Size.Width, 591);
                mainForm.panelContainer.Size = new Size(mainForm.panelContainer.Size.Width, 406);

                mainForm.Location = new Point(
                     (Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                     (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2
                 );
                // Perform layout if needed.
                mainForm.PerformLayout();

            }
        }
    }
}
