# Youtube Downloader Project

A .NET application for managing and interacting with audio and video streams using `YoutubeExplode` and other utilities. This project includes features such as downloading, merging streams, and managing configuration settings.

## Features

- **Singleton Pattern**: Centralized management of YouTube client operations.
- **Stream Selection**: Allows user to select quality of video and audio file.
- **Configuration Management**: Load and save application settings via `config.json`.
- **Stream Merging with ffmpeg**: Merge video and audio streams into a single file.

## Requirements

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)

- Visual Studio 2022 or later (for Windows)

- [YoutubeExplode 6.4.0](https://github.com/Tyrrrz/YoutubeExplode) NuGet Package.

- [Ffmpeg](https://github.com/BtbN/FFmpeg-Builds/releases)  tool.


## Setup

1. Clone the repository:

```bash
   git clone https://github.com/v-okur/youtube-downloader-win
   cd youtube-downloader-win
```

2. Install dependencies via NuGet:

```bash
   dotnet restore
```

3. Build the project:

```bash
   dotnet build
```

4. Run the application:

```bash
   dotnet run
```

## Configuration

The application uses a `config.json` file for managing user settings such as download folders. By default, it is generated in the application's root directory. 

### Example `config.json`

```json
{
  "DefaultDownloadFolder": "C:\\Users\\YourName\\Videos",
  "DefaultTemporaryFolder": "C:\\Users\\YourName\\Documents\\Temp"
}
```

## Usage

### Singleton Pattern for YouTube Operations
`YoutubeHandler` centralizes YouTube API calls and provides reusable methods for downloading and merging streams.

```csharp
var youtubeHandler = YoutubeHandler.Instance;
var video = await youtubeHandler.GetVideoAsync("https://youtube.com/your-video-id");
```

### Merging Audio and Video Streams with FFmpeg

The application uses `ffmpeg` to merge video and audio streams into a single file. Here's the basic command for merging an audio and video stream:

```bash

ffmpeg -i videoPath -i audioPath -c copy outputPath
```

This command combines the `videoPath` (video file) and `audioPath` (audio file) into a single output file at `outputPath` without re-encoding (`-c copy`), ensuring fast and lossless merging.

Example usage:

```bash

ffmpeg -i "video.mp4" -i "audio.mp3" -c copy "merged_output.mp4"
```

Make sure you have **FFmpeg** installed on your system and its executable is available in your system's `PATH`.  
**If FFmpeg is not installed or not accessible in your PATH, the merging operation will fail!**



## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss improvements.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.


