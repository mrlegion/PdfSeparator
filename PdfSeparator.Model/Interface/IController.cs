using PdfSeparator.Model.Common;

namespace PdfSeparator.Model.Interface
{
    public interface IController
    {
        void Notify(IComponent component, Events events, string message);
        void Log(string message);

        bool IsOpen { get; }
        bool IsClose { get; }

        void Open(string file);
        void Close();

        void SafeLog();
        void SafeLog(string directory);
    }
}
