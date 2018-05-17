using System;
using System.Collections.Generic;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class InformerComponent : IInformerComponent
    {
        /// <summary>
        /// Получение или установка ссылки на посредника
        /// </summary>
        public IMediator Controller { get; set; }

        /// <summary>
        /// Получение или установка стратегии получения информации
        /// </summary>
        public IInformerStrategy Strategy { get; set; }

        /// <summary>
        /// Получение обработанной информации об открытом файле
        /// </summary>
        /// <param name="chapters">Колекция глав, по которой и составляется информация о файле</param>
        /// <returns>Строковое сообщение с содержанием информации о файле</returns>
        public string GetInformation(IEnumerable<IChapter> chapters)
        {
            return Strategy.Proccess(chapters: chapters);
        }
    }
}