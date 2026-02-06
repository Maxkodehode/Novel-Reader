using System;
using System.IO;
using Novel_Reader;

public class FileChecker
{
    public static string? CheckFileType(string filePath)
    { 
        // Get the current save directory from settings
        string saveDirectory = ActionSettings.Instance.SaveDirectory 
                               ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        string extension = Path.GetExtension(filePath).ToLower();

        switch (extension)
        {
            case ".pdf":
                PDFConverter.PdfConvert(filePath, saveDirectory);
                break;
        }
        
        return null;
    }
}