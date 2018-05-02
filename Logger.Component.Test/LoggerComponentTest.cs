using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PdfSeparator.Model.Interface;

namespace Logger.Component.Test
{
    [TestFixture]
    public class LoggerComponentTest
    {
        public void Logging_RecordTest()
        {
            ILogger logger = new PdfSeparator.Model.Components.Logger();
        }
    }
}
