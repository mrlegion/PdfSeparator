using System.Collections;
using System.Collections.Generic;
using System.IO;
using PdfSeparator.Model.Common;

namespace PdfSeparator.Model.Interface
{
    public interface IController : IMediator
    {
        bool IsOpen { get; }

        void Open(FileInfo file);
        void Close();
        void SafeLog();
        void SafeLog(DirectoryInfo directory);
        void Info();
        void Separate(SeparateType type);
        void AddFilter(FilterItem filter);
        void AddFilter(IEnumerable<FilterItem> filters);
        void RemoveAtFilter(int id);
        void ClearFilters();
    }
}
