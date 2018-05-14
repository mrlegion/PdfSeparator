using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PdfSeparator.Model.Common.FIlterStategy;
using PdfSeparator.Model.Components;
using PdfSeparator.Model.Interface;


namespace FilterComponentTests
{
    [TestFixture]
    public class FilterComponentsTest
    {
        private IFilterComponent _filter;
        private IPdfComponent _pdf;

        private Queue<IChapter> _chapters;

        [SetUp]
        public void Init()
        {
            _filter = new FilterComponent();

            _pdf = new PdfComponent();
            _pdf.Open(new FileInfo(@"C:\Users\Alexander\Desktop\AMM new.pdf"));
            _chapters = _pdf.GetChapters;

            _pdf = null;
        }

        [Test]
        public void FilterComponent_Filter_AddBlankPageToEnd()
        {
            _filter.FilterStrategy = new AddBlankPageFilterStrategy();
            var f = _filter.ApplyFilters(chapters: _chapters);

            foreach (IChapter chapter in f)
            {
                if (chapter.Count % 2 != 0)
                    if (!chapter.AddBlankPageToEnd)
                        Assert.Fail("Имеется нечетное количество страниц!");
            }

            Assert.Pass("Все прекрасно работает");
        }
    }
}
