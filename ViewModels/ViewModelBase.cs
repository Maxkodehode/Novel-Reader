using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Novel_Reader.Helpers;

namespace Novel_Reader.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [RelayCommand]
    public async Task<string?> OpenNewFolder(Window window)
    {
        string? path = await DirectoryPicker.GetNovelFilePath(window);
        if (path != null)
        {
            return FileChecker.CheckFileType(path);
        }
        return null;
    }

    [RelayCommand]
    public static async Task<string?> ChangeSaveDirectory(Window window)
    {
        string? path = await DirectoryPicker.GetSaveDirectory(window);
        return SaveDirectory.WhichPath(path);
    }
}
