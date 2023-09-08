using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace MP3_YoutubeConverter
{
    public partial class UploadURLControl : UserControl
    {
        private readonly YouTubeService youtubeService;

        public UploadURLControl()
        {
            InitializeComponent();

            // Initialize the YouTubeService with your API Key
            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDAuK-6Fyeper2Z55yEu88C-kEXdm-i4I4"
            });
        }

        #region FUNCTION TO BROWSE THE YOUTUBE URL

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(youtubeUrlTextBox.Text))
            {
                MessageBox.Show("Please enter the required URL.");
                return;
            }

            // Get the YouTube video URL from the text box.
            string videoUrl = youtubeUrlTextBox.Text;

            // Extract the video ID from the URL.
            string videoId = GetVideoId(videoUrl);

            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("Invalid YouTube URL.");
                return;
            }

            ResizeMainForm();

            AccessTheYoutubeService(videoId);
        }

        #endregion

        #region FUNCTION TO RESIZE THE MAIN FORM

        private void ResizeMainForm()
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

        #endregion

        private async void AccessTheYoutubeService(string videoId)
        {
            // Check if the video ID is not empty.
            if (!string.IsNullOrEmpty(videoId))
            {
                var videoRequest = youtubeService.Videos.List("snippet");
                videoRequest.Id = videoId;

                var videoResponse = await videoRequest.ExecuteAsync();

                if (videoResponse.Items.Count > 0)
                {
                    string thumbnailUrl = videoResponse.Items[0].Snippet.Thumbnails.Maxres.Url;
                    string videoTitle = videoResponse.Items[0].Snippet.Title;

                    await LoadImageAsync(thumbnailUrl);

                    // Display the title and duration
                    titleBox.Text = videoTitle;
                }
            }
            else
                MessageBox.Show("Invalid YouTube URL.");
        }

        private string GetVideoId(string url)
        {
            // Extract the video ID from the YouTube URL
            if (url.Contains("youtube.com"))
            {
                try
                {
                    var uri = new Uri(url);
                    var query = uri.Query;
                    var videoId = System.Web.HttpUtility.ParseQueryString(query).Get("v");
                    return videoId;
                }
                catch
                {
                    return null;
                }
            }
            else if (url.Contains("youtu.be"))
            {
                try
                {
                    var uri = new Uri(url);
                    return uri.Segments[1];
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private async Task LoadImageAsync(string thumbnailUrl)
        {
            // Assuming thumbnailUrl is the URL of the retrieved thumbnail
            using (var webClient = new WebClient())
            {
                try
                {
                    byte[] imageBytes = await webClient.DownloadDataTaskAsync(thumbnailUrl);

                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        // Load the image into a temporary variable
                        var tempImage = Image.FromStream(memoryStream);

                        thumbnailBox.Image = tempImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }
            }
        }

    }
}
