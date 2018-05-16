using System;
using System.Collections.Generic;
using System.IO;
using PdfSeparator.Model.Interface;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Common.FIlterStategy;
using PdfSeparator.Model.Common.PdfSepatareStrategy;
using PdfSeparator.Model.Components;
using Prism.Mvvm;

namespace PdfSeparator.Model
{
    public class ControllerModel : BindableBase, IController
    {
        #region Link to all components

        /// <summary>
        /// Компонент управления ведением журнала событий в приложении
        /// </summary>
        private readonly ILoggerComponent _logger;

        /// <summary>
        /// Компонент управления pdf файлами
        /// </summary>
        private readonly IPdfComponent _pdfComponent;

        /// <summary>
        /// Компонент управления применением фильтров для колекции страниц
        /// </summary>
        private readonly IFilterComponent _filter;

        #endregion

        #region Fields
        
        private SeparateType _separateType;

        private bool _documentIsOpen;

        private bool _addBlankPageToEnd;

        #endregion

        #region Properties

        public bool DocumentIsOpened
        {
            get => _documentIsOpen;
            private set => SetProperty(ref _documentIsOpen, value);
        }

        public SeparateType DocumentSeparateType
        {
            get => _separateType;
            set => SetProperty(ref _separateType, value);
        }

        public bool AddBlankPageToEnd
        {
            get => _addBlankPageToEnd;
            set => SetProperty(ref _addBlankPageToEnd, value);
        }
        
        #endregion

        #region Construct

        public ControllerModel()
        {
            // Инициализация компонентов и передача ссылки на посредника
            _logger = new LoggerComponent() { Controller = this };
            _pdfComponent = new PdfComponent() { Controller = this };
            _filter = new FilterComponent() { Controller = this };
        }

        #endregion

        #region Impliment IController

        public void Notify(IComponent component, Events events, string message)
        {
            switch (events)
            {
                case Events.OpenDocument:
                    DocumentIsOpened = ((IPdfComponent)component).IsOpen;
                    Log(message: message);
                    break;
            }
        }

        /// <summary>
        /// Внесение информации в журнал событий
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Log(string message) => _logger.Logging(message: message);

        public void Open(FileInfo file)
        {
            _pdfComponent.Open(file: file);
        }

        public void Close()
        {
            _pdfComponent.Close();
        }

        public void SafeLog()
        {
            _logger.SaveLogToFile();
        }

        public void SafeLog(DirectoryInfo directory)
        {
            _logger.SaveLogToFile(directory: directory);
        }

        public void Info()
        {
            throw new NotImplementedException();
        }

        public void Separate()
        {
            // Создаем временную переменую для глав
            IEnumerable<IChapter> chapters = null;

            // TODO: Сделать передачу стратегии в PDFComponent тут!
            switch (DocumentSeparateType)
            {
                // Делем документ по форматам в одном файле
                case SeparateType.InOneFile:
                    _pdfComponent.SeparateStrategy = new InOneFileStrategy();
                    break;
                // Делем документ по форматам в очередности глав, каждая глава в отдельном файле
                case SeparateType.EachInSeparateFile:
                    _pdfComponent.SeparateStrategy = new EachInSeparateFileStrategy();
                    break;
            }

            // Проверяем необходимость применять фильтр
            if (AddBlankPageToEnd)
            {
                _filter.FilterStrategy = new AddBlankPageFilterStrategy();
                chapters = _filter.ApplyFilters(_pdfComponent.GetChapters);
            }
            else chapters = _pdfComponent.GetChapters;

            _pdfComponent.Separate(chapters);
        }

        #endregion

        #region Control methods



        #endregion
    }
}
