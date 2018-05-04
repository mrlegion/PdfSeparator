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

        /// <summary>
        /// Проверка открытия файла в компонете
        /// </summary>
        [Test]
        public void PdfComponent_Open()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            _pdf.Open(PDF_FILE);

            Assert.IsTrue(_pdf.IsOpen);
        }

        /// <summary>
        /// Проверка на исключение при повторном открытии файла без закрытия предыдущего
        /// </summary>
        [Test]
        public void PdfComponent_OpenSecondary()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            // Открываем файл в компоненте
            _pdf.Open(PDF_FILE);

            // Проверяем на исключение при попытке открыть повторно или другой файл в компоненте
            Assert.Throws<Exception>(() => _pdf.Open(PDF_FILE));
        }

        /// <summary>
        /// Проверка на закрытие файла
        /// </summary>
        [Test]
        public void PdfComponent_Close()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            // Открываем файл в компоненте
            _pdf.Open(PDF_FILE);

            // Закрываем файл в компоненте
            _pdf.Close();

            Assert.IsFalse(_pdf.IsOpen);
        }

        /// <summary>
        /// Проверка на повторное закрытие файла при его отсутствии в компоненте
        /// </summary>
        [Test]
        public void PdfComponent_CloseSecondary()
        {
            // Проверяем на исключение при попытке закрыть повторно файл в компоненте
            Assert.Throws<Exception>(() => _pdf.Close());
        }

        /// <summary>
        /// Проверка получения коллекции глав по форматам
        /// </summary>
        [Test]
        public void PdfComponent_GetCharpters()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";
            
            // Открываем файл в компоненте
            _pdf.Open(PDF_FILE);

            Assert.IsNotEmpty(_pdf.GetChapters);
        }

        /// <summary>
        /// Проверка получения количества страниц в документе
        /// </summary>
        [Test]
        public void PdfComponent_Count()
        {
            const string PDF_FILE = @"C:\Users\Alexander\Desktop\ИУС\НАЦИОНАЛЬНЫЕ СТАНДАРТЫ.pdf";

            // Открываем файл в компоненте
            _pdf.Open(PDF_FILE);

            Assert.AreNotEqual(0, _pdf.Count);
        }
    }
}
