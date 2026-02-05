using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Pdf;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Novel_Reader.ViewModelBase;

namespace Novel_Reader;

public class PDFConverter : ViewModels.MainWindowViewModel
{
    public static void PdfConvert(string path, string targetFolder)
    {
        var document = new Document(path);
        string fileName = Path.GetFileNameWithoutExtension(path);
        
        var newPath = SaveDirectory.WhichPath(path);
        
        string FinalPath = path.Replace(".pdf", ".epub");
        document.Save(newPath, SaveFormat.Epub);
    }
}
