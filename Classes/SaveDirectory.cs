using System;
using System.IO;
using Novel_Reader.ViewModelBase;

namespace Novel_Reader.ViewModelBase;

public class SaveDirectory
{
    public static string DirectoryLocation { get; set; } =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public static void WhichPath(string newPath)
    {
        string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        if (!string.IsNullOrEmpty(newPath) && Directory.Exists(newPath))
        {
            DirectoryLocation = newPath;
        }

        DirectoryLocation = userDocuments;
    }
}
