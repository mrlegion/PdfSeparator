using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class FilterComponent : IFilter
    {
        public IController Controller { get; set; }
    }
}
