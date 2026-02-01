using System.IO;

namespace Novel_Reader;

public class FileChecker
{
    public static void CheckFileType(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        
        switch (extension)
        {
            case ".pdf":
            var converter = new PDFConverter();
            converter.Pdfconvert(filePath);
            break;
            }
    }
}