using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;
using System.Net.Http;

namespace MP3_YoutubeConverter
{
    public partial class ConvertMP3Control : UserControl
    {
        // Property to store the Youtube URL
        public string YoutubeURL { get; set; }

        private readonly YoutubeClient youtubeClient = new YoutubeClient();

        public ConvertMP3Control()
        {
            InitializeComponent();
        }

        private void ConvertMP3Control_Load(object sender, EventArgs e)
        {
            YoutubeURLConversion(sender, e);
        }

        private async void YoutubeURLConversion(object sender, EventArgs e)
        {
            progressBar.Value = 0; // Reset progress bar at the start of the process

            var videoUrl = YoutubeURL;

            try
            {
                // Get video info
                var videoInfo = await youtubeClient.Videos.GetAsync(videoUrl);

                // Update progress bar and label
                progressBar.Value = 25;
                loadingPercent.Text = "25%";

                // Get media stream info set
                var mediaStreamInfoSet = await youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

                // Update progress bar and label
                progressBar.Value = 50;
                loadingPercent.Text = "50%";

                // Get the best audio stream
                var audioStreamInfo = mediaStreamInfoSet.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (audioStreamInfo != null)
                {
                    statusLabel.Text = "DOWNLOADING";

                    using (var httpClient = new HttpClient())
                    {
                        var mp3StreamUrl = audioStreamInfo.Url;

                        // Allow the user to choose the save location
                        var saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = $"{videoInfo.Title}.mp3";
                        saveFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var response = await httpClient.GetAsync(mp3StreamUrl, HttpCompletionOption.ResponseHeadersRead))
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            using (var fs = File.OpenWrite(saveFileDialog.FileName))
                            {
                                var buffer = new byte[65536]; // 64 KB buffer
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                {
                                    await fs.WriteAsync(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes != -1)
                                    {
                                        // Calculate and update the progress
                                        var progress = (int)((double)totalBytesRead / totalBytes * 100);
                                        progressBar.Value = progress;
                                        loadingPercent.Text = progress + "%";
                                    }
                                }
                            }

                            // Update progress bar and label
                            progressBar.Value = 100; // For example, you're 100% done here
                            loadingPercent.Text = "100%";
                            statusLabel.Text = "COMPLETED";
                            convertAgainBtn.Enabled = true;

                            MessageBox.Show("Downloaded MP3 file: " + saveFileDialog.FileName);
                        }
                        else
                        {
                            backBtn_Click(sender, e);
                            MessageBox.Show("Download canceled by the user.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No audio stream found for the video.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
    }
}
