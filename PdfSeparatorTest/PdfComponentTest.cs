using System;
using System.Collections.Generic;
using System.IO;
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
        private IPdfComponent _pdfComponent;
        private const string PdfFile = @"C:\Users\Alexander\Desktop\AIPC 04.00\M7_92_AIPC_Chapter011_000_RU_04_00.PDF";
        private FileInfo _fi;

        [SetUp]
        public void Init()
        {
            _pdfComponent = new PdfComponent();
            _fi = new FileInfo(PdfFile);
        }

        /// <summary>
        /// Проверка открытия файла в компонете
        /// </summary>
        [Test]
        public void PdfComponent_Open()
        {
            _pdfComponent.Open(_fi);

            Assert.IsTrue(_pdfComponent.IsOpen);
        }

        /// <summary>
        /// Проверка на исключение при повторном открытии файла без закрытия предыдущего
        /// </summary>
        [Test]
        public void PdfComponent_OpenSecondary()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            // Проверяем на исключение при попытке открыть повторно или другой файл в компоненте
            Assert.Throws<Exception>(() => _pdfComponent.Open(_fi));
        }

        /// <summary>
        /// Проверка на закрытие файла
        /// </summary>
        [Test]
        public void PdfComponent_Close()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            // Закрываем файл в компоненте
            _pdfComponent.Close();

            Assert.IsFalse(_pdfComponent.IsOpen);
        }

        /// <summary>
        /// Проверка на повторное закрытие файла при его отсутствии в компоненте
        /// </summary>
        [Test]
        public void PdfComponent_CloseSecondary()
        {
            // Проверяем на исключение при попытке закрыть повторно файл в компоненте
            Assert.Throws<Exception>(() => _pdfComponent.Close());
        }

        /// <summary>
        /// Проверка получения коллекции глав по форматам
        /// </summary>
        [Test]
        public void PdfComponent_GetCharpters()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            Assert.AreNotEqual(0, _pdfComponent.GetChapters.Count);
        }

        /// <summary>
        /// Проверка получения количества страниц в документе
        /// </summary>
        [Test]
        public void PdfComponent_Count()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            Assert.AreNotEqual(0, _pdfComponent.Count);
        }
    }
}
