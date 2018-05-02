using PdfSeparator.Model.Common;

namespace PdfSeparator.Model.Interface
{
    public interface IController
    {
        void Notify(IComponent component, Events events, string message);
        void Log(string message);
    }
}
