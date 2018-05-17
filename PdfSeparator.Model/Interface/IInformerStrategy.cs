using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IInformerStrategy
    {
        string Proccess(IEnumerable<IChapter> chapters);
    }
}