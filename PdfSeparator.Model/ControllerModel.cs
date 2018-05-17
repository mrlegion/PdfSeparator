using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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

        /// <summary>
        /// Компонент для получения информации об открытом файле
        /// </summary>
        private IInformerComponent _informer;

        #endregion

        #region Fields
        
        /// <summary>
        /// Тип стратегии деления документа по форматам
        /// </summary>
        private SeparateType _separateType;

        /// <summary>
        /// Статус открытия документа в модели
        /// </summary>
        private bool _documentIsOpen;

        /// <summary>
        /// Статус необходимости добавления пустой страницы к конец документа
        /// у глав с нечетным количеством страниц
        /// </summary>
        private bool _addBlankPageToEnd;

        #endregion

        #region Properties

        /// <summary>
        /// Получение или установка статуса открытости документа в модели
        /// </summary>
        public bool DocumentIsOpened
        {
            get => _documentIsOpen;
            private set => SetProperty(ref _documentIsOpen, value);
        }

        /// <summary>
        /// Получение или установка типа стратегии деления документа
        /// </summary>
        public SeparateType DocumentSeparateType
        {
            get => _separateType;
            set => SetProperty(ref _separateType, value);
        }

        /// <summary>
        /// Получение или установка статуса необходимости добавление пустой страницы
        /// в конец документа у глав с нечетным количеством страниц
        /// </summary>
        public bool AddBlankPageToEnd
        {
            get => _addBlankPageToEnd;
            set => SetProperty(ref _addBlankPageToEnd, value);
        }
        
        #endregion

        #region Construct

        /// <summary>
        /// Инициализания нового экземпляра объекта <seealso cref="ControllerModel"/>
        /// </summary>
        public ControllerModel()
        {
            // Инициализация компонентов и передача ссылки на посредника
            _logger = new LoggerComponent() { Controller = this };
            _pdfComponent = new PdfComponent() { Controller = this };
            _filter = new FilterComponent() { Controller = this };
            _informer = new InformerComponent() { Controller = this };
        }

        #endregion

        #region Impliment IController

        /// <summary>
        /// Оповещение посредника <seealso cref="IController"/> о изменениях у компонентов
        /// </summary>
        /// <param name="component">Компонент с которым связан посредник типа <see cref="IComponent"/></param>
        /// <param name="events">Событие, которое вызывает компонет из списка <seealso cref="Events"/></param>
        /// <param name="message">Сообщенее, которое передает компонент посреднику</param>
        /// <returns></returns>
        public bool Notify(IComponent component, Events events, string message)
        {
            switch (events)
            {
                // Обработка события открытия документа
                case Events.OpenDocument:
                    DocumentIsOpened = ((IPdfComponent)component).IsOpen;
                    Log(message: message);
                    break;
                // Обработка события при создании новой директории и которая уже существует
                case Events.DirectoryIsAlreadyExist:
                    message = message + Environment.NewLine + "Перезаписать указаную директорию?";
                    var dialog = MessageBox.Show(messageBoxText: message, caption: "Директория уже существует",
                        icon: MessageBoxImage.Question, button: MessageBoxButton.YesNo);
                    if (dialog == MessageBoxResult.Yes)
                        return true;
                    else return false;
            }

            return true;
        }

        /// <summary>
        /// Внесение информации в журнал событий
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Log(string message) => _logger.Logging(message: message);

        /// <summary>
        /// Открытие PDF файла в модели для возможности дальнейшего его обработки
        /// </summary>
        /// <param name="file">Информация об открываемом файле в типе <seealso cref="FileInfo"/></param>
        public void Open(FileInfo file)
        {
            _pdfComponent.Open(file: file);
        }

        /// <summary>
        /// Сохранения журнала событий в папке с разделеными документами
        /// </summary>
        public void SafeLog()
        {
            _logger.SaveLogToFile();
        }

        /// <summary>
        /// Сохранение журнала событий в указаной директории
        /// </summary>
        /// <param name="directory">Директория, в которую следует сохранить журнал событий</param>
        public void SafeLog(DirectoryInfo directory)
        {
            _logger.SaveLogToFile(directory: directory);
        }

        /// <summary>
        /// Получение информации об открытом файле
        /// </summary>
        public void Info()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Деление документа по форматам с выбранной ранее стратегией
        /// </summary>
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
