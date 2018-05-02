using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSeparator.Interface;

namespace PdfSeparator.Models.Components
{
    public class PdfComponet : IPdf
    {
        private Queue<IChapter> _chapters;

        public Queue<IChapter> GetChapters => _chapters;

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
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
