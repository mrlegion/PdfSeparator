using System.Collections.Generic;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common.FIlterStategy
{
    /// <summary>
    /// Стратегия фильтрации, при которой анализируется количество страниц в главе и приводиться к четному количеству
    /// </summary>
    public class AddBlankPageFilterStrategy : IFilterStrategy
    {
        /// <summary>
        /// Провести фильтрацию переданной коллекции
        /// </summary>
        /// <param name="chapters">Коллекция глав</param>
        /// <returns>Новая коллекция, которая отфильтрована в соответствии с требованиями</returns>
        public IEnumerable<IChapter> Proccess(IEnumerable<IChapter> chapters)
        {
            var result = new Queue<IChapter>(chapters);
            // Перебор коллекции
            foreach (IChapter chapter in result)
            {
                // Проверка на четность страниц в главе
                if (chapter.Count % 2 != 0)
                {
                    // Если количество страниц не четное, ставим флаг,
                    // что требуется добавить пустую страницу при делении в конец документа
                    chapter.AddBlankPageToEnd = true;
                }
            }

            return result;
        }
    }
}