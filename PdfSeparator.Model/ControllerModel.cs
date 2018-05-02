using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Model.Interface;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Components;

namespace PdfSeparator.Model
{
    public class ControllerModel : IController
    {
        #region Link to all components

        /// <summary>
        /// Компонент управления ведением журнала событий в приложении
        /// </summary>
        private readonly Logger _logger;

        /// <summary>
        /// Компонент управления pdf файлами
        /// </summary>
        private readonly PdfComponet _pdf;

        /// <summary>
        /// Компонент управления применением фильтров для колекции страниц
        /// </summary>
        private readonly FilterComponent _filter;

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

        #endregion
    }
}
