using System;
using System.IO;
using System.Text;
using UglyToad.PdfPig;

namespace Novel_Reader;

public class PDFConverter
{
    public static string PdfConvert(string path, string targetFolder)
    {
        string fileName = Path.GetFileNameWithoutExtension(path);
        string outputPath = Path.Combine(targetFolder, fileName + ".txt");
        
        try
        {
            using (var document = PdfDocument.Open(path))
            {
                var text = new StringBuilder();
                
                foreach (var page in document.GetPages())
                {
                    text.AppendLine(page.Text);
                    text.AppendLine(); // Add spacing between pages
                }
                
                File.WriteAllText(outputPath, text.ToString());
            }
            
            return outputPath;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to convert PDF: {ex.Message}", ex);
        }
    }
}