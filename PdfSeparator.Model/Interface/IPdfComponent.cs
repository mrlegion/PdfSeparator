using System.Collections.Generic;
using System.IO;

namespace PdfSeparator.Model.Interface
{
    public interface IPdfComponent : IComponent
    {
        bool IsOpen { get; }
        Queue<IChapter> GetChapters { get; }
        int Count { get; }

        void Open(FileInfo file);
        void Close();
        void CopyTo();
    }
}