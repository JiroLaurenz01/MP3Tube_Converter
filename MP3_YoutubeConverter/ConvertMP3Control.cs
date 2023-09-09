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

        #region FUNCTION TO CONVERT THE YOUTUBE URL TO MP3

        private async void YoutubeURLConversion(object sender, EventArgs e)
        {
            progressBar.Value = 0; // Reset progress bar at the start of the process.

            var videoUrl = YoutubeURL; // Store the YouTube video URL from a global variable.

            try
            {
                // Get video info.
                var videoInfo = await youtubeClient.Videos.GetAsync(videoUrl);

                // Update progress bar and label to indicate 25% completion.
                progressBar.Value = 25;
                loadingPercent.Text = "25%";

                // Get media stream info set.
                var mediaStreamInfoSet = await youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

                // Update progress bar and label to indicate 50% completion.
                progressBar.Value = 50;
                loadingPercent.Text = "50%";

                // Get the best audio stream using the GetWithHighestBitrate() function.
                var audioStreamInfo = mediaStreamInfoSet.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (audioStreamInfo != null)
                {
                    statusLabel.Text = "DOWNLOADING"; // Set label to indicate downloading is in progress.

                    using (var httpClient = new HttpClient())
                    {
                        var mp3StreamUrl = audioStreamInfo.Url; // Get the URL of the audio stream.

                        // Allow the user to choose the save location for the MP3 file.
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            FileName = $"{videoInfo.Title}.mp3", // Set the default file name based on video title
                            Filter = "MP3 Files (*.mp3)|*.mp3" // Specify the file filter
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK) // If the user selects a save location.
                        {
                            using (var response = await httpClient.GetAsync(mp3StreamUrl, HttpCompletionOption.ResponseHeadersRead))
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            using (var fs = File.OpenWrite(saveFileDialog.FileName))
                            {
                                var buffer = new byte[65536]; // Create a buffer for downloading in chunks.
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1; // Get the total file size if available.

                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                {
                                    await fs.WriteAsync(buffer, 0, bytesRead); // Write the downloaded data to the file.
                                    totalBytesRead += bytesRead;

                                    if (totalBytes != -1)
                                    {
                                        // Calculate and update the download progress as a percentage.
                                        var progress = (int)((double)totalBytesRead / totalBytes * 100);
                                        progressBar.Value = progress;
                                        loadingPercent.Text = progress + "%";
                                    }
                                }
                            }

                            // Update progress bar and label to indicate completion.
                            progressBar.Value = 100;
                            loadingPercent.Text = "100%";
                            statusLabel.Text = "COMPLETED"; // Set label to indicate download is completed
                            convertAgainBtn.Enabled = true; // Enable a button for further conversion

                            MessageBox.Show("Downloaded MP3 file: " + saveFileDialog.FileName); // Show a message with the downloaded file name.
                        }
                        else
                        {
                            backBtn_Click(sender, e); // Trigger a back button click event.
                            MessageBox.Show("Download canceled by the user."); // Show a message indicating download cancellation.
                        }
                    }
                }
                else
                    MessageBox.Show("No audio stream found for the video."); // Show a message if no audio stream is found.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Show an error message if an exception occurs.
            }
        }

        #endregion

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
