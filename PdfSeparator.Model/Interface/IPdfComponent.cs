using System.Collections.Generic;
using System.IO;
using PdfSeparator.Model.Common;

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
        /// Октрытие файла в компоненте IPdfComponent
        /// </summary>
        /// <param name="file">Ссылка на файл в виде информационного объекта <seealso cref="FileInfo"/></param>
        void Open(FileInfo file);

        /// <summary>
        /// Закрытие текущего открытого файла в компоненте
        /// </summary>
        void Close();

        /// <summary>
        /// Копирование диапазона страниц в новый pdf файл
        /// </summary>
        void CopyTo();

        /// <summary>
        /// Разбитие открытого файла по форматам
        /// </summary>
        void Separate(SeparateType type);
    }
}