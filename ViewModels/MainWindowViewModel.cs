using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Novel_Reader.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private double _readerFontSize = 16;

    [ObservableProperty]
    private string _readerFontFamily = "Arial";

    [ObservableProperty]
    private string _contentText = "Please select a file to begin.";

    public MainWindowViewModel() { }

    public async Task OpenAndRead(Window window)
    {
        string? filePath = await OpenNewFolder(window);

        if (!string.IsNullOrEmpty(filePath))
        {
            try
            {
                ContentText = await File.ReadAllTextAsync(filePath);
            }
            catch (Exception ex)
            {
                ContentText = $"Failed to load novel: {ex.Message}";
            }
        }
    }
}
