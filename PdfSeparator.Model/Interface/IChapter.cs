using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    // ToDo: Добавить комментарии
    public interface IChapter
    {
        string Format { get; set; }
        int Start { get; }
        int End { get; }
        int Count { get; }
        List<IPage> Pages { get; set; }
        bool AddBlankPageToEnd { get; set; }
    }
}