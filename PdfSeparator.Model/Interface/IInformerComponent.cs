using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IInformerComponent : IComponent
    {
        /// <summary>
        /// Получение или установка стратегии получения информации
        /// </summary>
        IInformerStrategy Strategy { get; set; }

        /// <summary>
        /// Получение обработанной информации об открытом файле
        /// </summary>
        /// <param name="chapters">Колекция глав, по которой и составляется информация о файле</param>
        /// <returns>Строковое сообщение с содержанием информации о файле</returns>
        string GetInformation(IEnumerable<IChapter> chapters);
    }
}