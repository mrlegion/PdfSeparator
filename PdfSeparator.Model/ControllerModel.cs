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
        private readonly ILogger _logger;

        /// <summary>
        /// Компонент управления pdf файлами
        /// </summary>
        private readonly IPdf _pdf;

        /// <summary>
        /// Компонент управления применением фильтров для колекции страниц
        /// </summary>
        private readonly IFilter _filter;

        #endregion

        #region Properties

        public bool IsOpen => _pdf.IsOpen;

        public bool IsClose => _pdf.IsClose;

        #endregion

        #region Construct

        public ControllerModel()
        {
            // Инициализация компонентов и передача ссылки на посредника
            _logger = new Logger() { Controller = this };
            _pdf = new PdfComponet() { Controller = this };
            _filter = new FilterComponent() { Controller = this }; 
        }

        #endregion

        #region Impliment IController

        public void Notify(IComponent component, Events events, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Внесение информации в журнал событий
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Log(string message) => _logger.Logging(message: message);

        public void Open(string file)
        {
            _pdf.Open(file: file);
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void SafeLog()
        {
            throw new NotImplementedException();
        }

        public void SafeLog(string directory)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Control methods

        

        #endregion
    }
}
