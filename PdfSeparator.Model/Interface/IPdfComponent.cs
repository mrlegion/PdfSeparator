using System.Collections.Generic;
using System.IO;

namespace PdfSeparator.Model.Interface
{
    public interface IPdfComponent : IComponent
    {
        bool IsOpen { get; }
        void Open(FileInfo file);
        void Close();
        Queue<IChapter> GetChapters { get; }
        int Count { get; }
    }
}