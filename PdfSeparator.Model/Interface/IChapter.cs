using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IChapter
    {
        /// <summary>
        /// Получение или установка наименование формата главы
        /// </summary>
        string Format { get; set; }

        /// <summary>
        /// Получение или установка имени для главы
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Получение номера страницы начала главы
        /// </summary>
        int Start { get; }

        /// <summary>
        /// Получение номера страницы окончания главы
        /// </summary>
        int End { get; }

        /// <summary>
        /// Получение общего количества страниц в данной главе
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Получение или установка коллекции страниц входящие в главу
        /// </summary>
        List<IPage> Pages { get; set; }

        /// <summary>
        /// Получение или установка необходимости добавления пустой страницы в конце главы
        /// </summary>
        bool AddBlankPageToEnd { get; set; }
    }
}