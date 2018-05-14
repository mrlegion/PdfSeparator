using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IFilterComponent : IComponent
    {
        /// <summary>
        /// Получение или установка стратегии для фильтрации колекции
        /// </summary>
        IFilterStrategy FilterStrategy { get; set; }

        /// <summary>
        /// Фильтрация полученной коллекции при открытии файла на основе выбранной стратегии фильтрации
        /// </summary>
        /// <param name="chapters">Коллекция глав полученной при анализе открытия файла</param>
        /// <returns>Отфильтрованная коллекция по выбранным параметрам</returns>
        IEnumerable<IChapter> ApplyFilters(IEnumerable<IChapter> chapters);
    }
}