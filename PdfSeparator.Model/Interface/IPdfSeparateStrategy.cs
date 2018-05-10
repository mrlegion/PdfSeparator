using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IPdfSeparateStrategy
    {
        void SeparateFile(IEnumerable<IChapter> chapters);
    }
}