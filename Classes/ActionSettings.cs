using CommunityToolkit.Mvvm.ComponentModel;

namespace Novel_Reader;

// This is your ONE settings class. It holds both:
// - UI state (IsПaneOpen, ContentText, SelectedFile)
// - Persistent settings (FontSize, FontFamily, Colors, SaveDirectory)
// SettingsService will save and load this entire object to/from JSON.

public partial class ActionSettings : ObservableObject
{
    public static ActionSettings Instance { get; } = new();

    [ObservableProperty]
    private string? _saveDirectory;

    [ObservableProperty]
    private double _readerFontSize = 16;

    [ObservableProperty]
    private string _readerFontFamily = "Arial";

    [ObservableProperty]
    private string _contentText = "Please select a file to begin.";

    [ObservableProperty]
    private string _selectedFile = "";

    [ObservableProperty]
    private string _backGroundColor = "#282828";

    [ObservableProperty]
    private string _textColor = "#D5C4A1";

    [ObservableProperty]
    private bool _isPaneOpen = true;
}