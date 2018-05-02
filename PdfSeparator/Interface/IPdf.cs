using System.Collections.Generic;

namespace PdfSeparator.Interface
{
    public interface IPdf : IComponent
    {
        void Open(string file);
        void Close();
        Queue<IChapter> GetChapters { get; }
    }
}