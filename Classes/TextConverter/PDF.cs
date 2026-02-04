using System;
using System.Threading.Tasks;
using Aspose.Pdf;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Novel_Reader;

public class PDFConverter : ViewModels.MainWindowViewModel
{
    public static void PdfConvert(string path)
    {
        var document = new Document(path);
        var newPath = SaveToThisDirectory;
        string newName = path.Replace(".pdf", ".epub");
        document.Save(newName, SaveFormat.Epub);
    }
}
