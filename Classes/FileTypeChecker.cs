using System.IO;

namespace Novel_Reader.MainWindowViewModel;

public class FileChecker
{
    public static void CheckFileType(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();

        switch (extension)
        {
            case ".pdf":

                PDFConverter.PdfConvert(filePath);
                break;
        }
    }
}
