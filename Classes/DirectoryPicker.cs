using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using System.Linq;
namespace Novel_Reader;

public static class DirectoryPicker
{
    public static async Task<string?> GetSaveDirectory(Window parentWindow)
    {
        var storage = parentWindow.StorageProvider;

        var result = await storage.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Folder to Save Novels",
            AllowMultiple = false
        });

        return result.FirstOrDefault()?.Path.LocalPath;
    }
    
    public static async Task<string?> GetNovelFilePath(Window parentWindow)
    {
        var storage = parentWindow.StorageProvider;

        var result = await storage.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Novel File",
            AllowMultiple = true,
            FileTypeFilter = new[] 
            { 
                new FilePickerFileType("E-books") { Patterns = new[] { "*.pdf", "*.epub", "*.txt" } } 
            }
        });

        return result.FirstOrDefault()?.Path.LocalPath;
    }
}