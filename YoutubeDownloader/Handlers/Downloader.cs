using YoutubeExplode.Videos.Streams;
using System.Threading.Tasks;
using System;

namespace YoutubeDownloader.Handlers;

public static class Downloader
{
    /// <summary>
    /// Downloads the video or audio via given stream 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static async Task DownloadStreamAsync(IStreamInfo stream, string fileName)
    {
        var youtube = new YoutubeExplode.YoutubeClient();
        await youtube.Videos.Streams.DownloadAsync(stream, fileName);
    }
}
