using System.IO;
using Novel_Reader.ViewModelBase;

namespace Novel_Reader.MainWindowViewModel;

public class FileChecker:SaveDirectory
{
    public static string? CheckFileType(string filePath)
    { 
        string saveDirectory = WhichPath(path);
        string extension = Path.GetExtension(filePath).ToLower();

        switch (extension)
        {
            case ".pdf":

                PDFConverter.PdfConvert(filePath, saveDirectory);
                break;
        }
        
    }
}
