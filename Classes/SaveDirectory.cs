using System;
using System.IO;

namespace Novel_Reader.Helpers;

public class SaveDirectory : ActionSettings
{
    public static string WhichPath(string? newPath)
    {
        string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        if (!string.IsNullOrEmpty(newPath) && Directory.Exists(newPath))
        {
            Instance.SaveDirectory = newPath;
            return newPath;
        }

        Instance.SaveDirectory = userDocuments;
        return userDocuments;
    }
}
