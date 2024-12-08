using System.Text.Json;

public class AppConfig
{
    // The name of the configuration file.
    private const string ConfigFileName = "config.json";

    /// <summary>
    /// The default folder where downloaded videos will be stored.
    /// Defaults to the user's "My Videos" folder.
    /// </summary>
    public string DefaultDownloadFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

    /// <summary>
    /// The default temporary folder for storing temporary files.
    /// Defaults to a "Temp" folder in the user's "My Documents" directory.
    /// </summary>
    public string DefaultTemporaryFolder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YoutubeDownloader", "Temp");

    /// <summary>
    /// Loads the application configuration from the "config.json" file.
    /// If the file doesn't exist or the deserialization fails, returns a new <see cref="AppConfig"/> instance.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="AppConfig"/> with the settings loaded from the configuration file, 
    /// or default values if the file doesn't exist or can't be read.
    /// </returns>
    public static AppConfig Load()
    {
        // Check if the config file exists
        if (File.Exists(ConfigFileName))
        {
            // Read the content of the config file
            string json = File.ReadAllText(ConfigFileName);

            // Deserialize the JSON into an AppConfig object
            // If deserialization fails, return a new AppConfig with default values
            return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
        }

        // If config file doesn't exist, return a new AppConfig with default values
        return new AppConfig();
    }

    /// <summary>
    /// Serializes the current configuration object to JSON and saves it to the "config.json" file.
    /// </summary>
    public void Save()
    {
        // Serialize the current AppConfig object to a JSON string
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

        // Write the serialized JSON string to the config file
        File.WriteAllText(ConfigFileName, json);
    }
}
