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
        private PdfReader _reader;
        private PdfWriter _writer;
        private PdfDocument _document;

        private int _count;
        private bool _isOpen;

        private Queue<IChapter> _chapters;

        public Queue<IChapter> GetChapters => _chapters;

        public int Count => _count;

        public bool IsOpen => _isOpen;

        public IMediator Controller { get; set; }

        #region Construct

        public PdfComponent()
        {
            _chapters = new Queue<IChapter>();
        }

        #endregion

        #region Private Method

        private void FillChapters()
        {
            IChapter chapter = null;

            for (int i = 1; i <= Count; i++)
            {
                PdfPage pdfPage = _document.GetPage(i);
                var pdfPageSize = pdfPage.GetPageSize();

                IPage page = new Page(width: pdfPageSize.GetWidth(), heigth: pdfPageSize.GetHeight(), position: i);

                if (chapter == null)
                    chapter = new Chapter(format: page.Format);

                if (chapter.Format.Contains(page.Format))
                    chapter.Pages.Add(page);
                else
                {
                    _chapters.Enqueue(chapter);
                    chapter = new Chapter(page.Format);
                }
            }

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

            _reader = new PdfReader(file);
            _document = new PdfDocument(_reader);
            _count = _document.GetNumberOfPages();
            _isOpen = true;

            FillChapters();
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

        #endregion
    }
}