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
using TheArtOfDevHtmlRenderer.Adapters;

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
                ApiKey = "AIzaSyCtmMTphze3U2xeGm6stIy2DEcN86zVsP0"
            });
        }

        #region FUNCTION TO RESET THE YOUTUBE URL TEXT BOX BY CLICKING THE RIGHT ICON

        private void youtubeUrlTextBox_IconRightClick(object sender, EventArgs e) => youtubeUrlTextBox.Clear();

        #endregion

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

            LoadingScreenForm loadingScreenForm = new LoadingScreenForm();
            loadingScreenForm.ShowDialog();

            _ = AccessTheYoutubeServiceAsync(videoId);

            ResizeMainForm();

            AlertForm alertForm = new AlertForm();
            alertForm.Alert("Loaded Successfully", AlertForm.Type.Success);
        }

        #endregion     

        #region FUNCTION TO RESIZE THE MAIN FORM

        private void ResizeMainForm()
        {
            // Get a reference to the MainForm if it exists.
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

            if (mainForm != null)
            {
                mainForm.Size = new Size(mainForm.Size.Width, 550);
                mainForm.panelContainer.Size = new Size(mainForm.panelContainer.Size.Width, 365);

                mainForm.Location = new Point(
                     (Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                     (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2
                 );
                // Perform layout if needed.
                mainForm.PerformLayout();
            }
        }

        #endregion

        #region FUNCTIONS TO ACCESS THE YOUTUBE SERVICE TO GET THE THUMBNAIL AND TITLE

        private async Task AccessTheYoutubeServiceAsync(string videoId)
        {
            try
            {
                // Create a request to retrieve video details (snippet) from YouTube.
                var videoRequest = youtubeService.Videos.List("snippet");

                // Set the video ID in the request.
                videoRequest.Id = videoId;

                // Execute the video request asynchronously and await the response.
                var videoResponse = await videoRequest.ExecuteAsync();

                // Check if there are video items in the response.
                if (videoResponse.Items.Count > 0)
                {
                    // Get the URL of the video's max resolution thumbnail.
                    // Get the video title from the response.
                    string thumbnailUrl = videoResponse.Items[0].Snippet.Thumbnails.Maxres.Url;
                    string videoTitle = videoResponse.Items[0].Snippet.Title;

                    // Load the video thumbnail asynchronously.
                    await LoadImageAsync(thumbnailUrl);

                    // Display the video title in the titleBox control.
                    titleBox.Text = videoTitle;
                }
                else
                    MessageBox.Show("Video response is empty.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Video response failed: {ex.Message}");
            }
        }

        private string GetVideoId(string url)
        {
            // Extract the video ID from the YouTube URL.
            if (url.Contains("youtube.com"))
            {
                try
                {
                    // Parse the URL to extract the query string.
                    var uri = new Uri(url);
                    var query = uri.Query;

                    // Use the query string to get the video ID.
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
                    // Extract the video ID from the shortened URL.
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
            // Use a WebClient to download the thumbnail image asynchronously.
            using (var webClient = new WebClient())
            {
                try
                {
                    // Download the image as a byte array.
                    byte[] imageBytes = await webClient.DownloadDataTaskAsync(thumbnailUrl);

                    // Create a MemoryStream from the downloaded bytes.
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        // Load the image from the MemoryStream.
                        var tempImage = Image.FromStream(memoryStream);

                        // Set the loaded image as the thumbnailBox's image.
                        thumbnailBox.Image = tempImage;
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message if image loading fails.
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }
            }
        }

        #endregion

        #region FUNCTION FOR CONVERT BUTTON

        private void convertBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the MainForm if it exists.
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

            if (mainForm != null)
            {
                LoadingScreenForm loadingScreenForm = new LoadingScreenForm();
                loadingScreenForm.ShowDialog();

                ConvertMP3Control convertMP3Control = new ConvertMP3Control();
                convertMP3Control.YoutubeURL = youtubeUrlTextBox.Text;

                mainForm.Size = new Size(mainForm.Size.Width, 303);
                mainForm.panelContainer.Size = new Size(mainForm.panelContainer.Size.Width, 118);

                mainForm.Location = new Point(
                     (Screen.PrimaryScreen.WorkingArea.Width - mainForm.Width) / 2,
                     (Screen.PrimaryScreen.WorkingArea.Height - mainForm.Height) / 2
                 );
                // Perform layout if needed.
                mainForm.PerformLayout();

                mainForm.addUserControl(convertMP3Control);
            }
        }

        #endregion
    }
}
