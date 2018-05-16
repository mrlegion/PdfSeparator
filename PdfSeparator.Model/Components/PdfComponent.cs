using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.Kernel.Pdf;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class PdfComponent : IPdfComponent
    {
        /// <summary>
        /// Pdf reader on iText
        /// </summary>
        private PdfReader _reader;

        /// <summary>
        /// Pdf Document on iText
        /// </summary>
        private PdfDocument _document;

        /// <summary>
        /// Информация о директории, в которой находится открытый файл
        /// </summary>
        private DirectoryInfo _directory;

        /// <summary>
        /// Информация о самом открытом файле в данный момент
        /// </summary>
        private FileInfo _file;

        /// <summary>
        /// Значение определяющее открыт ли в данный момент какой-либо файл
        /// </summary>
        private bool _isOpen;

        /// <summary>
        /// Очередь глав в файле
        /// </summary>
        private readonly Queue<IChapter> _chapters;

        /// <summary>
        /// Получение или установка стратегии при разбинии файла по главам
        /// </summary>
        public IPdfSeparateStrategy SeparateStrategy { get; set; }

        /// <summary>
        /// Получение очереди глав в файле
        /// </summary>
        public Queue<IChapter> GetChapters => _chapters;

        /// <summary>
        /// Получение количества страниц в файле
        /// </summary>
        public int Count => _document.GetNumberOfPages();

        /// <summary>
        /// Получение статуса о состоянии документа
        /// </summary>
        public bool IsOpen => _isOpen;

        /// <summary>
        /// Получение или установка ссылки на посредника
        /// </summary>
        public IMediator Controller { get; set; }

        #region Construct

        /// <summary>
        /// Создание экземпляра класса PdfComponent
        /// </summary>
        public PdfComponent()
        {
            _chapters = new Queue<IChapter>();
        }

        #endregion

        #region Private Method
        
        // Todo: подумать о более простой реализации данного метода
        /// <summary>
        /// Заполнение очереди глав
        /// </summary>
        private void FillChapters()
        {
            // Объявляем главу
            IChapter chapter = null;

            // Перебор всех страниц документа
            for (int i = 1; i <= Count; i++)
            {
                // Инициализируем класс объекта страницы документа
                PdfPage pdfPage = _document.GetPage(i);
                // Получаем размеры страницы
                var pdfPageSize = pdfPage.GetPageSize();

                // Инициализируем класс хранитель для страницы и заполняем его
                IPage page = new Page(width: pdfPageSize.GetWidth(), heigth: pdfPageSize.GetHeight(), position: i);

                // проверяем на первую страницу документа и если это первая страница, то инициализируем главу
                if (chapter == null)
                    chapter = new Chapter(format: page.Format);

                // Проверяем, если формат страницы соответсвует формату главы,
                // то добавляем эту страницу в колекцию страниц
                if (chapter.Format.Contains(page.Format))
                    chapter.Pages.Add(page);
                // Если это другой формат
                else
                {
                    // то добавляем главу в очередь
                    _chapters.Enqueue(chapter);
                    // и инициализируем главу новым форматом
                    chapter = new Chapter(page.Format);
                    // а затем ее добавляем в список
                    chapter.Pages.Add(page);
                }
            }

            // Добавляем последнюю главу в очередь
            _chapters.Enqueue(chapter);
            chapter = null;
        }

        #endregion 

        #region Public method

        /// <summary>
        /// Открытие pdf файла и загрузка его в память
        /// </summary>
        /// <param name="file">Путь до файла</param>
        public void Open(FileInfo file)
        {
            if (IsOpen)
                throw new Exception("Pdf file is ready open! Please first close odl file!");

            if (!file.Exists)
                throw new FileNotFoundException($"File: {file.FullName} is not found!");

            _reader = new PdfReader(file);
            _document = new PdfDocument(_reader);
            _isOpen = true;

            _file = file;
            _directory = _file.Directory;
            
            FillChapters();

            Controller.Notify(component: this, events: Events.OpenDocument, message: "Документ открыт");
        }

        public void Close()
        {
            if (!IsOpen) throw new Exception("Pdf file is not open! Please first load and open file!");

            _document?.Close();
            _reader?.Close();

            _document = null;
            _reader = null;

            _isOpen = false;
        }

        public void CopyTo()
        {
            throw new NotImplementedException();
        }

        // ToDo: сделать преим параметра коллекции IChapters
        public void Separate(IEnumerable<IChapter> chapters)
        {
            // Создаем новый путь
            var newDirectory = new DirectoryInfo(Path.Combine(path1: _directory.FullName,
                path2: Path.GetFileNameWithoutExtension(_file.Name)));
            // Проверяем директорию на сущестование
            // Todo: сделать пересылку сообщений о существовании директории
            if (!newDirectory.Exists) newDirectory.Create();

            // Разбеваем файл
            SeparateStrategy.SeparateFile(document: _document, chapters: chapters, directory: newDirectory);
        }

        #endregion
    }
}