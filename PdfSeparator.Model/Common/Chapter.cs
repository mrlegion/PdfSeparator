using System.Collections.Generic;
using System.Linq;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common
{
    // ToDo: Добавить комментарии
    public class Chapter : IChapter
    {
        public string Format { get; set; }
        public int Start => Pages.First().Position;
        public int End => Pages.Last().Position;
        public int Count => Pages.Count;
        public List<IPage> Pages { get; set; }
        public bool AddBlankPageToEnd { get; set; }

        public Chapter(string format)
            : this(format: format, pages: new List<IPage>())
        { }

        public Chapter(string format, List<IPage> pages)
        {
            Format = format;
            Pages = pages;
        }
    }
}