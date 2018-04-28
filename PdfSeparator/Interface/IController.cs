using PdfSeparator.Common;

namespace PdfSeparator.Interface
{
    public interface IController
    {
        void Notify(IComponent component, Events events, string message);
        void Log(string message);
    }
}
