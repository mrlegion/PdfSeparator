using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common.PdfSepatareStrategy
{
    public class EachInSeparateFileStrategy : IPdfSeparateStrategy
    {
        public void SeparateFile(PdfDocument document, IEnumerable<IChapter> chapters, DirectoryInfo directory)
        {
            // Переводим коллекцию Chapters в список
            var chp = chapters.ToList();
            // Проверяем ее на пустоту
            if (chp == null) throw new ArgumentNullException();

            for (int i = 0; i < chp.Count; i++)
            {
                // Создаем информацию о новом файле
                FileInfo fi = new FileInfo(Path.Combine(directory.FullName, $"{chp[i].Format}_{i + 1}.pdf"));
                // Открываем файл для записи
                PdfWriter writer = new PdfWriter(fi);
                PdfDocument newDocument = new PdfDocument(writer);

                // Копируем диапазон страниц в новый файл
                document.CopyPagesTo(chp[i].Start, chp[i].End, newDocument);
                // Проверка на флаг добавления новой страницы в главе
                // Если есть, то добавляем
                if (chp[i].AddBlankPageToEnd) newDocument.AddNewPage();

                // Закрытие компонентов
                newDocument.Close();
                writer.Close();
            }
        }
    }
}