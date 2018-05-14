using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class FilterComponent : IFilterComponent
    {
        /// <summary>
        /// Получение или установка ссылки на посредника
        /// </summary>
        public IMediator Controller { get; set; }

        /// <summary>
        /// Получение или установка стратегии для фильтрации колекции
        /// </summary>
        public IFilterStrategy FilterStrategy { get; set; }

        /// <summary>
        /// Фильтрация полученной коллекции при открытии файла на основе выбранной стратегии фильтрации
        /// </summary>
        /// <param name="chapters">Коллекция глав полученной при анализе открытия файла</param>
        /// <returns>Отфильтрованная коллекция по выбранным параметрам</returns>
        public IEnumerable<IChapter> ApplyFilters(IEnumerable<IChapter> chapters)
        {
            return FilterStrategy.Proccess(chapters: chapters);
        }
    }
}
