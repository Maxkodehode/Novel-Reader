using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Novel_Reader.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ActionSettings Settings { get; } = new ActionSettings();

    public async Task OpenAndRead(Window window)
    {
        string ContentText;
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
