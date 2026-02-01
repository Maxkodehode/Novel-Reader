using Aspose.Pdf;

namespace Novel_Reader;

public class PDFConverter
{
    public static void PdfConvert(string path)
    {
        var document = new Document(path);
        string newName = path.Replace(".pdf", ".epub");
        document.Save(newName, SaveFormat.Epub);
    }
}
