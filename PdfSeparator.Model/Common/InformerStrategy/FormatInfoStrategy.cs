using System;
using System.Collections.Generic;
using System.Linq;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common.InformerStrategy
{
    public class FormatInfoStrategy : IInformerStrategy
    {
        public string Proccess(IEnumerable<IChapter> chapters)
        {
            string result = "";

            // Групперуем коллекцию по форматам
            var formatGroup = from chapter in chapters group chapter by chapter.Format;

            foreach (var g in formatGroup)
            {
                string line = $"Формат: {g.Key};{Environment.NewLine}Страницы: {Environment.NewLine}";
                int count = 0;
                foreach (IChapter chapter in g)
                {
                    line += $"[ {chapter.Start} - {chapter.End} ], ";
                    count += chapter.Count;
                }

                result += $"{line}{Environment.NewLine}Общее количество страниц: {count}{Environment.NewLine}{Environment.NewLine}";
            }

            return result;
        }
    }
}