using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
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

    [RelayCommand]
    public async Task<string?> ChangeSaveDirectory(Window window)
    {
        string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }
}
