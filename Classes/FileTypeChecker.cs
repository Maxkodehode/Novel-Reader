using System;
using System.IO;
using Novel_Reader;

public class FileChecker : ActionSettings
{
    public static string? CheckFileType(string filePath)
    { 
        string saveDirectory = ActionSettings.Instance.SaveDirectory 
                               ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        string extension = Path.GetExtension(filePath).ToLower();

        switch (extension)
        {
            case ".pdf":
            case ".txt":
            case ".html":
            case ".htm":
            case ".mobi":
            case ".azw":
            case ".azw3":
            case ".docx":
            case ".doc":
            case ".rtf":
                
               return Instance.ContentText = PDFConverter.ConvertToEpub(filePath, saveDirectory);
                 
            
            case ".epub":
                
                string fileName = Path.GetFileName(filePath);
                
                string targetPath = Path.Combine(saveDirectory, fileName);
                File.Copy(filePath, targetPath, overwrite: true);
                return targetPath;
            
            default:
                throw new Exception($"Unsupported file format: {extension}");
        }
    }
}