using System.Collections.Generic;
using System.IO;
using System.Linq;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using PdfSeparator.Model.Interface;
using Path = System.IO.Path;

namespace PdfSeparator.Model.Common.PdfSepatareStrategy
{
    public class InOneFileStrategy : IPdfSeparateStrategy
    {
        public void SeparateFile(PdfDocument document, IEnumerable<IChapter> chapters, DirectoryInfo directory)
        {
            // Групперуем коллекцию по форматам
            var formatGroup = from chapter in chapters group chapter by chapter.Name;

            foreach (IGrouping<string, IChapter> group in formatGroup)
            {
                // Создаем информацию о новом файле
                FileInfo fi = new FileInfo(Path.Combine(directory.FullName, $"{group.Key}.pdf"));
                // Открываем файл для записи
                PdfWriter writer = new PdfWriter(fi);
                PdfDocument newDocument = new PdfDocument(writer);

                // Копируем диапазон страниц в новый файл
                foreach (IChapter chapter in group)
                {
                    document.CopyPagesTo(chapter.Start, chapter.End, newDocument);
                    // Проверяем, есть ли флаг на добавлене пустой страницы в конце документа
                    // если есть, добавляем
                    if (chapter.AddBlankPageToEnd) newDocument.AddNewPage(new PageSize((float)chapter.Pages[0].Width, (float)chapter.Pages[0].Heigth));
                }

                newDocument.Close();
                writer.Close();
            }
        }
    }
}