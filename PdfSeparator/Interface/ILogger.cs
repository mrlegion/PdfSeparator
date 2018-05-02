namespace PdfSeparator.Interface
{
    public interface ILogger : IComponent
    {
        void Logging(string message);
        void SaveLogToFile();
    }
}