using System;
using System.IO;
using System.Text.Json;

namespace Novel_Reader.Services;

// This class has one job: save ActionSettings to a JSON file, and load it back.
// It does NOT hold any settings itself — ActionSettings.Instance is the data.

public class SettingsService
{
    private readonly string _settingsPath;
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public SettingsService()
    {
        // The JSON file will be saved at:
        // Windows: C:\Users\YOU\AppData\Roaming\NovelReader\settings.json
        // Linux:   ~/.config/NovelReader/settings.json
        // macOS:   ~/Library/Preferences/NovelReader/settings.json
        var appDataDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NovelReader"
        );

        Directory.CreateDirectory(appDataDir);
        _settingsPath = Path.Combine(appDataDir, "settings.json");

        Load();
    }

    public void Load()
    {
        if (!File.Exists(_settingsPath))
            return; // No file yet? Just use the defaults defined in ActionSettings

        try
        {
            var json = File.ReadAllText(_settingsPath);

            // Read each value from JSON and apply it to ActionSettings.Instance
            var loaded = JsonSerializer.Deserialize<SettingsData>(json);
            if (loaded == null) return;

            ActionSettings.Instance.SaveDirectory    = loaded.SaveDirectory;
            ActionSettings.Instance.ReaderFontSize   = loaded.ReaderFontSize;
            ActionSettings.Instance.ReaderFontFamily = loaded.ReaderFontFamily;
            ActionSettings.Instance.BackGroundColor  = loaded.BackGroundColor;
            ActionSettings.Instance.TextColor        = loaded.TextColor;
        }
        catch
        {
            // If the file is corrupted, just use defaults. No crash.
        }
    }

    public void Save()
    {
        // Snapshot only the settings you want to persist (not UI state like ContentText)
        var data = new SettingsData
        {
            SaveDirectory    = ActionSettings.Instance.SaveDirectory,
            ReaderFontSize   = ActionSettings.Instance.ReaderFontSize,
            ReaderFontFamily = ActionSettings.Instance.ReaderFontFamily,
            BackGroundColor  = ActionSettings.Instance.BackGroundColor,
            TextColor        = ActionSettings.Instance.TextColor,
        };

        var json = JsonSerializer.Serialize(data, _jsonOptions);
        File.WriteAllText(_settingsPath, json);
    }

    // A plain data class — only used internally for JSON serialization.
    // This is intentionally separate so we don't accidentally serialize
    // things like ContentText or IsPaneOpen into the settings file.
    private class SettingsData
    {
        public string? SaveDirectory    { get; set; }
        public double  ReaderFontSize   { get; set; } = 16;
        public string  ReaderFontFamily { get; set; } = "Arial";
        public string  BackGroundColor  { get; set; } = "#282828";
        public string  TextColor        { get; set; } = "#D5C4A1";
    }
}