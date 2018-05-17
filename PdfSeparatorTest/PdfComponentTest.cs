using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Common.FIlterStategy;
using PdfSeparator.Model.Common.PdfSepatareStrategy;
using PdfSeparator.Model.Components;
using PdfSeparator.Model.Interface;

namespace PdfSeparatorTest
{
    [TestFixture]
    public class PdfComponentTest
    {
        private IPdfComponent _pdfComponent;
        private const string PdfFile = @"C:\Users\Alexander\Desktop\AMM new.pdf";
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
        /// Проверка на количество страниц в коллекции глав
        /// </summary>
        [Test]
        public void PdfComponent_CheckCountPage()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            // Получение количества страниц в очереди
            var count = _pdfComponent.GetChapters.Sum(chapter => chapter.Count);

            Assert.AreEqual(_pdfComponent.Count, count);
        }

        /// <summary>
        /// Проверка получения количества страниц в документе
        /// </summary>
        [Test]
        public void PdfComponent_Count()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            Assert.AreEqual(14672, _pdfComponent.Count);
        }

        /// <summary>
        /// Проверка разделения документка по форматам
        /// </summary>
        [Test]
        public void PdfComponent_Sepatare_InOneFile()
        {
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            // Добавление новой стратегии
            _pdfComponent.SeparateStrategy = new InOneFileStrategy();

            // Разделение файла по форматам
            _pdfComponent.Separate(_pdfComponent.GetChapters);

            FileInfo f1 = new FileInfo(@"C:\Users\Alexander\Desktop\AMM new\a3.pdf");
            FileInfo f2 = new FileInfo(@"C:\Users\Alexander\Desktop\AMM new\a4.pdf");

            if (f1.Exists && f2.Exists)
                Assert.Pass("Success");

            Assert.Fail("File is not created");
        }

        /// <summary>
        /// Проверка разделения документка по форматам
        /// </summary>
        [Test]
        public void PdfComponent_Sepatare_EachInSeparateFile()
        {
            
            // Открываем файл в компоненте
            _pdfComponent.Open(_fi);

            // Добавление новой стратегии
            _pdfComponent.SeparateStrategy = new EachInSeparateFileStrategy();

            // Разделение файла по форматам
            _pdfComponent.Separate(_pdfComponent.GetChapters);

            var fileCount = Directory.GetFiles(@"C:\Users\Alexander\Desktop\AMM new\");

            Assert.IsTrue( _pdfComponent.GetChapters.Count == fileCount.Length );

        }
    }
}
