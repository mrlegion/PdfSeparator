using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PdfSeparator.Model.Components;
using PdfSeparator.Model.Interface;

namespace PdfSeparatorTest
{
    [TestFixture]
    public class PdfComponentTest
    {
        private IPdf _pdf;

        [SetUp]
        public void Init()
        {
            _pdf = new PdfComponet();
        }

        [Test]
        public void PdfComponent_Open()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            _pdf.Open(PDF_FILE);

            Assert.IsTrue(_pdf.IsOpen);
        }

        [Test]
        public void PdfComponent_Close()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            _pdf.Open(PDF_FILE);

            _pdf.Close();

            Assert.IsFalse(_pdf.IsOpen);
        }

        [Test]
        public void PdfComponent_GetCharpters()
        {

        }
    }
}
