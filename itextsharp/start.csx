// to run this sample, execute:-
// scriptcs start.csx

using iTextSharp.text;
using iTextSharp.text.pdf;

// extract pages 1 to 3 from input.pdf into output.pdf
ExtractPages("input.pdf", "output.pdf", 1, 3);

// from http://www.jamesewelch.com/2008/11/14/how-to-extract-pages-from-a-pdf-document/
public static void ExtractPages(string inputFile, string outputFile,
    int start, int end)
{
    // get input document
    PdfReader inputPdf = new PdfReader(inputFile);

    // retrieve the total number of pages
    int pageCount = inputPdf.NumberOfPages;

    if (end < start || end > pageCount)
    {
        end = pageCount;
    }

    // load the input document
    Document inputDoc =
        new Document(inputPdf.GetPageSizeWithRotation(1));

    // create the filestream
    using (FileStream fs = new FileStream(outputFile, FileMode.Create))
    {
        // create the output writer 
        PdfWriter outputWriter = PdfWriter.GetInstance(inputDoc, fs);
        inputDoc.Open();
        PdfContentByte cb1 = outputWriter.DirectContent;

        // copy pages from input to output document
        for (int i = start; i <= end; i++)
        {
            inputDoc.SetPageSize(inputPdf.GetPageSizeWithRotation(i));
            inputDoc.NewPage();

            PdfImportedPage page =
                outputWriter.GetImportedPage(inputPdf, i);
            int rotation = inputPdf.GetPageRotation(i);

            if (rotation == 90 || rotation == 270)
            {
                cb1.AddTemplate(page, 0, -1f, 1f, 0, 0,
                    inputPdf.GetPageSizeWithRotation(i).Height);
            }
            else
            {
                cb1.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
            }
        }

        inputDoc.Close();
    }
}
