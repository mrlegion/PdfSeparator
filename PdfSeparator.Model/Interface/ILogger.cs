using System.Collections.Generic;
using System.IO;

namespace PdfSeparator.Model.Interface
{
    public interface ILogger : IComponent
    {
        Queue<string> Log { get; }
        void Logging(string message);
        void SaveLogToFile();
        void SaveLogToFile(DirectoryInfo directory);
        void ClearLog();
    }
}