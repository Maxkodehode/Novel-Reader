using System;
using System.Diagnostics;
using System.IO;

namespace Novel_Reader;

public class PDFConverter
{
    public static string ConvertToEpub(string sourcePath, string targetFolder)
    {
        string fileName = Path.GetFileNameWithoutExtension(sourcePath);
        string outputPath = Path.Combine(targetFolder, fileName + ".epub");
        
        // Check if Calibre is installed
        if (!IsCalibreInstalled())
        {
            throw new Exception("Calibre (ebook-convert) is not installed. Please install it with: sudo apt-get install calibre");
        }
        
        try
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "ebook-convert",
                Arguments = $"\"{sourcePath}\" \"{outputPath}\" --enable-heuristics",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            
            using (var process = Process.Start(processInfo))
            {
                if (process == null)
                {
                    throw new Exception("Failed to start ebook-convert process");
                }
                
                process.WaitForExit();
                
                if (process.ExitCode != 0)
                {
                    string error = process.StandardError.ReadToEnd();
                    throw new Exception($"Conversion failed: {error}");
                }
            }
            
            if (!File.Exists(outputPath))
            {
                throw new Exception("Conversion completed but output file was not created");
            }
            
            return outputPath;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to convert to EPUB: {ex.Message}", ex);
        }
    }
    
    private static bool IsCalibreInstalled()
    {
        try
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "which",
                Arguments = "ebook-convert",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            
            using (var process = Process.Start(processInfo))
            {
                process?.WaitForExit();
                return process?.ExitCode == 0;
            }
        }
        catch
        {
            return false;
        }
    }
}