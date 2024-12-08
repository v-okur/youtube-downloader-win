
using YoutubeDownloader.Handlers;
using YoutubeExplode.Videos.Streams;


namespace YoutubeDownloader
{
    public partial class FormMain : Form
    {

        private YoutubeHandler youtubeHandler;

        private AppConfig config;


        /// <summary>
        /// Initializes the main form of the application. 
        /// Sets up configurations, creates required directories, 
        /// and prepares the YouTube handler for video downloading.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            config = AppConfig.Load();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!Directory.Exists(config.DefaultTemporaryFolder))
            {
                Directory.CreateDirectory(config.DefaultTemporaryFolder);
            }

            youtubeHandler = YoutubeHandler.Instance;
            youtubeHandler.Path = config.DefaultDownloadFolder;

        }

        /// <summary>
        /// Updates the UI to indicate that a search operation is in progress.
        /// Disables user interactions, resets previous results, and displays a loading indicator.
        /// </summary>
        private void Searching()
        {
            // Reset the UI to clear any previous search results or errors
            Reset();
            // Disable the submit button to and reset prevent interactions during the search
            submitButton.Enabled = false;
            resetButton.Enabled = false;

            // Make the loading indicator (PictureBox) visible
            pictureBox1.Visible = true;

            // Refresh the PictureBox to ensure it is rendered immediately
            pictureBox1.Refresh();

            // Change the submit button's background color to a "disabled" appearance
            submitButton.BackColor = Color.FromArgb(235, 235, 228);

            // Disable the URL text box to prevent user input during the search
            urlTextBox.Enabled = false;

            // Adjust the bounds of the URL text box for consistent alignment
            urlTextBox.SetBounds(38, 0, 273, 29);


        }
        /// <summary>
        /// Updates the UI after successfully finding a video. 
        /// Enables user interactions and prepares the interface for displaying the video details.
        /// </summary>
        private void Found()
        {
            // Enable the submit button and reset button to allow further interactions
            submitButton.Enabled = true;
            resetButton.Enabled = true;

            // Hide the loading indicator
            pictureBox1.Visible = false;

            // Change the submit button's background color to indicate readiness
            submitButton.BackColor = Color.RoyalBlue;

            // Re-enable the URL text box for user input
            urlTextBox.Enabled = true;

            // Adjust the bounds of the URL text box to fit the updated layout
            urlTextBox.SetBounds(38, 0, 235, 29);
        }

        /// <summary>
        /// Resets the UI to its initial state, clearing all previous video search results and settings.
        /// Prepares the interface for a new search operation.
        /// </summary>
        private void Reset()
        {
            // Hide the loading indicator (PictureBox) and video thumbnail
            pictureBox1.Visible = false;
            thumbnailBox.Visible = false;

            // Hide the quality panel, as no video is currently selected
            qualityPanel.Visible = false;

            // Clear video details (duration and title)
            durationLabel.Text = "";
            titleLabel.Text = "";

            // Reset the bounds of the URL text box to its default size
            urlTextBox.SetBounds(38, 0, 273, 29);

            // Reset the video and audio quality comboboxes
            videoQualitySelection.Items.Clear();
            audioQualitySelection.Items.Clear();
        }



        private async void submitButton_Click(object sender, EventArgs e)
        {
            await SearchVideo();
        }

        private void urlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (urlTextBox.Enabled == true && e.KeyChar == (char)13)  // '13' the ASCII value of ENTER key
            {
                SearchVideo();

            }
        }

        /// <summary>
        /// Searches for video details using the provided URL, retrieves video and stream information, 
        /// and updates the UI to display the video details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task SearchVideo()
        {
            // Retrieve the URL from the text box
            var url = urlTextBox.Text;

            // Validate the URL input
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a valid URL.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Start the UI update for searching
                Searching();

                // Fetch video and stream information
                var video = await youtubeHandler.GetVideoAsync(url);
                var streamManifest = await youtubeHandler.GetStreamManifestAsync(video.Id);

                // Store video and audio stream information in Youtube Hanlder
                youtubeHandler.VideoStreams = streamManifest.GetVideoOnlyStreams();
                youtubeHandler.AudioStreams = streamManifest.GetAudioOnlyStreams();

                // Handle case when video is not found
                if (video == null)
                {
                    MessageBox.Show("Video not found. Please check the URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the UI with video details
                thumbnailBox.Visible = true;
                titleLabel.Text = $"{video.Title}";
                authorLabel.Text = $"Author: {video.Author}";
                durationLabel.Text = $"{video.Duration}";

                // Load the thumbnail from the highest resolution available
                var thumbnailUrl = video.Thumbnails[^1].Url;
                thumbnailBox.Load(thumbnailUrl);
                thumbnailBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // Populate quality selection options
                PopulateQualityOptions(streamManifest);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and notify the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Invalid URL or video ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore the UI to a ready state
                Found();
            }
        }


        /// <summary>
        /// Populates the quality options for both video and audio streams into the respective dropdowns.
        /// It clears existing items and adds new ones based on the provided <paramref name="streamManifest"/>.
        /// </summary>
        /// <param name="streamManifest">The stream manifest containing the available video and audio streams.</param>
        private void PopulateQualityOptions(StreamManifest streamManifest)
        {
            videoQualitySelection.Items.Clear();
            audioQualitySelection.Items.Clear();

            foreach (var videoStream in streamManifest.GetVideoOnlyStreams())
            {
                if (videoStream.Container.Name == "mp4")
                {
                    // Create a unique key for the video stream using its quality and container
                    string streamKey = $"{videoStream.VideoQuality} {videoStream.Container.Name}";

                    // Check if the stream already exists in the selection
                    var existingItem = videoQualitySelection.Items
                        .OfType<string>() // Ensure the item is treated as a string
                        .FirstOrDefault(item => item == streamKey);

                    if (existingItem != null)
                    {
                        // If an existing item is found, compare bitrates to decide which one to keep
                        var existingStream = streamManifest.GetVideoOnlyStreams()
                            .FirstOrDefault(vs =>
                                $"{vs.VideoQuality} {vs.Container.Name}" == streamKey);

                        if (existingStream != null && videoStream.Bitrate > existingStream.Bitrate)
                        {
                            // Replace the existing item if the new stream has a higher bitrate
                            videoQualitySelection.Items.Remove(existingItem);
                            videoQualitySelection.Items.Add(streamKey);
                        }
                    }
                    else
                    {
                        // Add the stream if no item with the same key exists
                        videoQualitySelection.Items.Add(streamKey);
                    }
                }
            }


            foreach (var audioStream in streamManifest.GetAudioOnlyStreams().Reverse())
            {
                // Create a unique key for the audio stream using its bitrate
                string streamKey = $"{audioStream.Bitrate}";

                // Check if the stream already exists in the selection
                var existingItem = audioQualitySelection.Items
                    .OfType<string>() // Ensure the item is treated as a string
                    .FirstOrDefault(item => item == streamKey);

                if (existingItem == null)
                {
                    // If no duplicate exists, add the stream directly
                    audioQualitySelection.Items.Add(streamKey);
                }
            }

            if (videoQualitySelection.Items.Count > 0)
                videoQualitySelection.SelectedIndex = 0;

            if (audioQualitySelection.Items.Count > 0)
                audioQualitySelection.SelectedIndex = 0;

            qualityPanel.Visible = true;
        }


        CancellationTokenSource cancellationTokenSource;
        /// <summary>
        /// Handles the download button click event. Initiates the process of downloading the selected video and audio streams,
        /// merging them into a final file, and saving it to the user's selected location.
        /// Displays progress in a progress bar and handles cancellation with a token.
        /// </summary>
        /// <param name="sender">The source of the event (the download button).</param>
        /// <param name="e">The event arguments.</param>
        private async void downloadButton_Click(object sender, EventArgs e)
        {
            // Create a new cancellation token source to allow cancellation of the download process.
            cancellationTokenSource = new CancellationTokenSource();

            // Get the token for cancellation.
            CancellationToken token = cancellationTokenSource.Token;

            try
            {
                // Get the selected video and audio stream from the dropdowns.
                VideoOnlyStreamInfo selectedVideoStream = youtubeHandler.VideoStreams.ToList()[videoQualitySelection.SelectedIndex];
                AudioOnlyStreamInfo selectedAudioStream = youtubeHandler.AudioStreams.ToList()[audioQualitySelection.SelectedIndex];

                // Configure the save file dialog to filter MP4 files and set the initial directory.
                saveFileDialog.Filter = "MP4 Files (*.mp4)|*.mp4";
                saveFileDialog.FileName = $"{youtubeHandler.Video.Title}.mp4";

                // Set the default path for the downloaded video.
                youtubeHandler.Path = Path.Combine(config.DefaultDownloadFolder, $"{saveFileDialog.FileName}.mp4");

                // Show the save file dialog and check if the user selects a valid file path.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the download path to the selected file name.
                    youtubeHandler.Path = saveFileDialog.FileName;

                    // Set temporary file names for video and audio streams.
                    string videoFileName = Path.Combine(config.DefaultTemporaryFolder, $"{youtubeHandler.Video.Id}-videoOnly.{selectedVideoStream.Container.Name}");
                    string audioFileName = Path.Combine(config.DefaultTemporaryFolder, $"{youtubeHandler.Video.Id}-audioOnly.{selectedAudioStream.Container.Name}");

                    // Initialize progress bar and make it visible.
                    progressBar.Value = 0;
                    progressBar.Visible = true;
                    cancelButton.Visible = true;

                    // Define a progress handler to update the progress bar during the download.
                    var progressHandler = new Progress<double>(value =>
                    {
                        // Update the progress bar by converting the progress value to percentage.
                        progressBar.Value = (int)(value * 100);
                    });

                    // Start downloading the video stream asynchronously.
                    await Task.Run(() => youtubeHandler.DownloadAndMergeAsync(selectedVideoStream, videoFileName, progressHandler, token), token);

                    // Start downloading the audio stream asynchronously.
                    await Task.Run(() => youtubeHandler.DownloadAndMergeAsync(selectedAudioStream, audioFileName, progressHandler, token), token);

                    // Merge the video and audio streams into one final file.
                    await FfmpegMerger.Merge(videoFileName, audioFileName);

                    // Check if the final video file exists after merging.
                    if (File.Exists(youtubeHandler.Path))
                    {
                        // Show a success message if the download is completed successfully.

                        MessageBox.Show("Download completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Catch and handle the case where the download was canceled by the user.
                MessageBox.Show("Download was canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Catch any other errors during the download process.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset the progress bar and hide it after the operation is complete.
                progressBar.Value = 0;
                progressBar.Visible = false;

                // Dispose of the cancellation token source to release resources.
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;

                // Hide the cancel button after the download process is done.
                cancelButton.Visible = false;
            }
        }




        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }



        /// <summary>
        /// Allows the user to select a folder to save downloaded files.
        /// Updates the application's default download folder configuration
        /// and notifies the user of the change via a message box.
        /// </summary>
        private void setDefaultDownloadFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Select a folder to save downloads";
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    config.DefaultDownloadFolder = folderBrowser.SelectedPath;
                    config.Save();
                    youtubeHandler.Path = folderBrowser.SelectedPath;
                    MessageBox.Show($"Download folder updated to: {config.DefaultDownloadFolder}", "Folder Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        /// <summary>
        /// Allows the user to select a folder to save temporary files.
        /// Updates the application's default temporary folder configuration
        /// and notifies the user of the change via a message box.
        /// </summary>
        private void setDefaultTemporaryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Select a folder for temporary files";
                folderBrowser.SelectedPath = config.DefaultTemporaryFolder;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {

                    config.DefaultTemporaryFolder = folderBrowser.SelectedPath;
                    config.Save();
                    youtubeHandler.Path = folderBrowser.SelectedPath;
                    MessageBox.Show($"Temporary folder updated to: {config.DefaultTemporaryFolder}", "Folder Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            urlTextBox.Text = "";
            Reset();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            urlTextBox.Focus();
        }
    }
}
