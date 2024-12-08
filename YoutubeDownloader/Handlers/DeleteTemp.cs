
namespace YoutubeDownloader.Handlers;


public static class DeleteTemp
{
    /// <summary>
    /// Deletes the temporary files
    /// </summary>
    /// <param name="videoFileName"></param>
    /// <param name="audioFileName"></param>
    public static void Delete(string tempVideoLocation, string tempAudioLocation)
    {

        // Delete the temporary video and audio files 
        if (File.Exists(tempVideoLocation))
        {
            File.Delete(tempVideoLocation);
        }
        if (File.Exists(tempAudioLocation))
        {
            File.Delete(tempAudioLocation);
        }
    }
}