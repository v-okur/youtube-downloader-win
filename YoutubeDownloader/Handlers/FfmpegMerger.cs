using System.Diagnostics;

namespace YoutubeDownloader.Handlers;

public static class FfmpegMerger
{
    static YoutubeHandler youtubeHandler = YoutubeHandler.Instance;
    public static async Task Merge(string videoFilePath, string audioFilePath)
    {
        try
        {
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-y -i \"{videoFilePath}\" -i \"{audioFilePath}\" -c copy \"{youtubeHandler.Path}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = ffmpeg })
            {
                process.OutputDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                        Console.WriteLine($"[OUTPUT]: {args.Data}");
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                        Console.WriteLine($"[ERROR]: {args.Data}");
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit());
                if (process.ExitCode != 0)
                    throw new Exception($"FFmpeg iþlemi baþarýsýz oldu. Çýkýþ kodu: {process.ExitCode}");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
        }
        finally
        {
            DeleteTemp.Delete(videoFilePath, audioFilePath);

        }
    }

}
