using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloader.Handlers
{

    /// <summary>
    /// Handles interactions with YouTube, including video retrieval, stream manifest fetching, 
    /// and video/audio downloading using the YoutubeClient library.
    /// This class implements a thread-safe singleton pattern to ensure a single instance.
    /// </summary>
    public class YoutubeHandler
    {
        // Singleton instance of YoutubeHandler
        private static YoutubeHandler? _instance;

        // Lock object for thread-safety in singleton instance creation
        private static readonly object _lock = new object();

        // YoutubeClient instance for interacting with YouTube API
        private readonly YoutubeClient youtubeClient;

        /// <summary>
        /// Stores information about the currently retrieved video.
        /// </summary>
        public Video Video { get; set; }

        /// <summary>
        /// Path where the video or audio will be saved.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Contains video-only stream information for the current video.
        /// </summary>
        public IEnumerable<VideoOnlyStreamInfo> VideoStreams { get; set; }

        /// <summary>
        /// Contains audio-only stream information for the current video.
        /// </summary>
        public IEnumerable<AudioOnlyStreamInfo> AudioStreams { get; set; }

        // Private constructor to enforce singleton pattern
        private YoutubeHandler()
        {
            youtubeClient = new YoutubeClient();
        }

        /// <summary>
        /// Gets the singleton instance of YoutubeHandler.
        /// Ensures only one instance exists throughout the application lifecycle.
        /// </summary>
        public static YoutubeHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) // Ensure thread safety when creating the instance
                    {
                        if (_instance == null)
                        {
                            _instance = new YoutubeHandler();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Retrieves video metadata from YouTube using the provided URL.
        /// </summary>
        /// <param name="url">The YouTube video URL.</param>
        /// <returns>
        /// A <see cref="Video"/> object containing video details, 
        /// or <c>null</c> if the video cannot be retrieved.
        /// </returns>
        public async Task<Video?> GetVideoAsync(string url)
        {
            try
            {
                // Retrieve video metadata from YouTube
                Video video = await youtubeClient.Videos.GetAsync(url);
                Video = video;
                return Video;
            }
            catch
            {
                // Return null if an error occurs
                return null;
            }
        }

        /// <summary>
        /// Fetches the stream manifest for a YouTube video by video ID.
        /// </summary>
        /// <param name="videoId">The ID of the YouTube video.</param>
        /// <returns>
        /// A <see cref="StreamManifest"/> object containing available streams for the video.
        /// </returns>
        public async Task<StreamManifest> GetStreamManifestAsync(string videoId)
        {
            // Retrieve the manifest of available streams for the given video ID
            return await youtubeClient.Videos.Streams.GetManifestAsync(videoId);
        }

        /// <summary>
        /// Downloads the specified stream and saves it to the provided path.
        /// Supports progress tracking and cancellation.
        /// </summary>
        /// <param name="stream">The stream information to download.</param>
        /// <param name="savePath">The path where the downloaded file will be saved.</param>
        /// <param name="progress">Optional progress tracker for monitoring download progress.</param>
        /// <param name="cancellationToken">Optional token to cancel the download process.</param>
        public async Task DownloadAndMergeAsync(
            IStreamInfo stream,
            string savePath,
            IProgress<double>? progress = null,
            CancellationToken cancellationToken = default)
        {
            // Download the specified stream and save it to the provided path
            await youtubeClient.Videos.Streams.DownloadAsync(stream, savePath, progress, cancellationToken);
        }
    }


}
