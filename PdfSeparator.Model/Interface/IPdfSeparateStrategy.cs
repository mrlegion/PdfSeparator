using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;

namespace PdfSeparator.Model.Interface
{
    public interface IPdfSeparateStrategy
    {
        void SeparateFile(PdfDocument document, IEnumerable<IChapter> chapters, DirectoryInfo directory);
    }
}