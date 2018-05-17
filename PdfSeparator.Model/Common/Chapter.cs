using System.Collections.Generic;
using System.Linq;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common
{
    // ToDo: Добавить комментарии
    public class Chapter : IChapter
    {
        /// <summary>
        /// Получение или установка наименование формата главы
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Получение или установка имени для главы
        /// </summary>
        public string Name => $"{Format}_{Pages.First().Orientation.ToString()}";

        /// <summary>
        /// Получение номера страницы начала главы
        /// </summary>
        public int Start => Pages.First().Position;

        /// <summary>
        /// Получение номера страницы окончания главы
        /// </summary>
        public int End => Pages.Last().Position;

        /// <summary>
        /// Получение общего количества страниц в данной главе
        /// </summary>
        public int Count => Pages.Count;

        /// <summary>
        /// Получение или установка коллекции страниц входящие в главу
        /// </summary>
        public List<IPage> Pages { get; set; }

        /// <summary>
        /// Получение или установка необходимости добавления пустой страницы в конце главы
        /// </summary>
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