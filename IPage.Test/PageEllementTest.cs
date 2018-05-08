using NUnit.Framework;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Interface;

namespace PageEllement.Test
{
    [TestFixture]
    public class PageEllementTest
    {
        private IPage _page;

        private double _width = 420.0;
        private double _height = 297.0;
        private int _position = 5;
        private PageOrientation _orintation = PageOrientation.Horizontal;
        private string _format = "a3";

        [SetUp]
        public void Init()
        {
            _page = new Page(width: (_width + 0.321) / 0.3528 , heigth: (_height - 0.52) / 0.3528, position: _position);
        }

        [Test]
        public void PageEllementTest_Width()
        {
            Assert.AreEqual(_width, _page.Width);
        }

        [Test]
        public void PageEllementTest_Heigth()
        {
            Assert.AreEqual(_height, _page.Heigth);
        }

        [Test]
        public void PageEllementTest_Orientation()
        {
            Assert.AreEqual(_orintation, _page.Orientation);
        }

        [Test]
        public void PageEllementTest_Format()
        {
            Assert.AreEqual(_format, _page.Format);
        }

        [Test]
        public void PageEllementTest_Position()
        {
            Assert.AreEqual(_position, _page.Position);
        }

    }
}
