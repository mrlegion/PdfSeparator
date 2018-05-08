using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Model.Interface;
using PdfSeparator.Model.Common;
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

        #region Properties

        public bool IsOpen => _pdfComponent.IsOpen;

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

        public void ClearFilters()
        {
            throw new NotImplementedException();
        }

        public void Notify(IComponent component, Events events, string message)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void SafeLog()
        {
            throw new NotImplementedException();
        }

        public void SafeLog(DirectoryInfo directory)
        {
            throw new NotImplementedException();
        }

        public void Info()
        {
            throw new NotImplementedException();
        }

        public void Separate()
        {
            throw new NotImplementedException();
        }

        public void AddFilter(FilterItem filter)
        {
            throw new NotImplementedException();
        }

        public void AddFilter(IEnumerable<FilterItem> filters)
        {
            if (filters == null) throw new ArgumentNullException(nameof(filters));

            foreach (FilterItem filter in filters)
            {
                AddFilter(filter);
            }
        }

        public void RemoveAtFilter(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Control methods

        

        #endregion
    }
}
