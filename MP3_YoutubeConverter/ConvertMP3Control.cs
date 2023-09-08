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
    public partial class ConvertMP3Control : UserControl
    {
        // Property to store the Youtube URL
        public string YoutubeURL { get; set; }

        public ConvertMP3Control()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the MainForm if it exists.
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

            if (mainForm != null)
            {
                LoadingScreenForm loadingScreenForm = new LoadingScreenForm();
                loadingScreenForm.ShowDialog();

                UploadURLControl uploadURLControl = new UploadURLControl();
                mainForm.addUserControl(uploadURLControl);
            }
        }

        private void ConvertMP3Control_Load(object sender, EventArgs e)
        {
            MessageBox.Show(YoutubeURL);
        }
    }
}
