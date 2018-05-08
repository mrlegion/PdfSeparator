using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class FilterComponent : IFilterComponent
    {
        public IMediator Controller { get; set; }
    }
}
