using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Novel_Reader.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [RelayCommand]
    public async Task<string?> OpenNewFolder(Window window)
    {
        // Remove the text here
        string? path = await DirectoryPicker.GetNovelFilePath(window); 
        return path;
    }
}
