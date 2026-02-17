using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace Novel_Reader.ViewModels;

// MainWindowViewModel is what your MainWindow.axaml binds to.
// It exposes ActionSettings.Instance as a property called "Settings"
// so your AXAML can do things like: FontSize="{Binding Settings.ReaderFontSize}"

public partial class MainWindowViewModel : ViewModelBase
{
    // Expose the single ActionSettings instance to the UI
    public ActionSettings Settings => ActionSettings.Instance;

    public async Task OpenAndRead(Window window)
    {
        string? filePath = await OpenNewFolder(window);

        if (!string.IsNullOrEmpty(filePath))
        {
            try
            {
                Settings.ContentText = await File.ReadAllTextAsync(filePath);
            }
            catch (Exception ex)
            {
                Settings.ContentText = $"Failed to load novel: {ex.Message}";
            }
        }
    }
}
