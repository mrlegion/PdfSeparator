using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Common;
using PdfSeparator.Interface;
using PdfSeparator.Models.Components;

namespace PdfSeparator.Models
{
    public class ControllerModel : IController
    {
        #region Link to all components

        /// <summary>
        /// Компонент управления ведением журнала событий в приложении
        /// </summary>
        private Logger _logger;

        #endregion


        #region Impliment IController

        public void Notify(IComponent component, Events events, string message)
        {
            
        }

        public void Log(string message)
        {
            
        }

        #endregion
    }
}
