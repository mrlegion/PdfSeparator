using System.Collections.Generic;
using System.IO;

namespace PdfSeparator.Model.Interface
{
    public interface IPdfComponent : IComponent
    {
        /// <summary>
        /// Получение значение статуса об состоянии открытости файла
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Получение списка глав разделенных по форматам
        /// </summary>
        Queue<IChapter> GetChapters { get; }

        /// <summary>
        /// Получение общего количества страниц в файле
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Получение или установка стратегии при разбинии файла по главам
        /// </summary>
        IPdfSeparateStrategy SeparateStrategy { get; set; }

        /// <summary>
        /// Октрытие файла в компоненте IPdfComponent
        /// </summary>
        /// <param name="file">Ссылка на файл в виде информационного объекта <seealso cref="FileInfo"/></param>
        void Open(FileInfo file);

        /// <summary>
        /// Разбитие открытого файла по форматам
        /// </summary>
        /// <param name="chapters">Коллекция глав, по которой будет происходить разделение документа</param>
        void Separate(IEnumerable<IChapter> chapters);
    }
}