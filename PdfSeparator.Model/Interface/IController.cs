using System.Collections;
using System.Collections.Generic;
using PdfSeparator.Model.Common;

namespace PdfSeparator.Model.Interface
{
    public interface IController
    {
        bool IsOpen { get; }

        void Open(string file);
        void Close();
        void SafeLog();
        void SafeLog(string directory);
        void Info();
        void Separate();
        void AddFilter(FilterItem filter);
        void AddFilter(IEnumerable<FilterItem> filters);
        void RemoveAtFilter(int id);
        void ClearFilters();

        void Notify(IComponent component, Events events, string message);
        void Log(string message);
    }
}
