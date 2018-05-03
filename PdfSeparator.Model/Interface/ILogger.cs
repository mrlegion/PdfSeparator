using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface ILogger : IComponent
    {
        Queue<string> Log { get; }
        void Logging(string message);
        void SaveLogToFile();
        void SaveLogToFile(string directory);
        void ClearLog();
    }
}