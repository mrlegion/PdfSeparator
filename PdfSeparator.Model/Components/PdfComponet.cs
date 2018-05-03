using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.Kernel.Pdf;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class PdfComponet : IPdf
    {
        private PdfReader _reader;
        private PdfWriter _writer;
        private PdfDocument _document;

        private int _count;
        private bool _isOpen;
        private bool _isClose;

        private Queue<IChapter> _chapters;

        public Queue<IChapter> GetChapters => _chapters;

        public int Count => _count;

        public bool IsOpen => _isOpen;
        public bool IsClose => _isClose;

        public IController Controller { get; set; }

        #region Construct

        public PdfComponet()
        {
            _chapters = new Queue<IChapter>();
        }

        #endregion

        #region Public method

        public void Open(string file)
        {
            if (IsOpen)
                throw new Exception("Pdf file is ready open! Please first close odl file!");

            if (!File.Exists(file))
            {
                _isOpen = false;
                throw new FileNotFoundException();
            }

            FontProgram font = FontProgramFactory.CreateFont("c:/windows/fonts/msgothic.ttc,1");

            _reader = new PdfReader(file);
            _document = new PdfDocument(_reader);
            _isOpen = true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
