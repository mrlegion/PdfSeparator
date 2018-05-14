using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IFilterStrategy
    {
        IEnumerable<IChapter> Proccess(IEnumerable<IChapter> chapters);
    }
}