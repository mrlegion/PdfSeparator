namespace PdfSeparator.Interface
{
    public interface IChapter
    {
        string Format { get; set; }
        int Start { get; set; }
        int End { get; set; }
        int Count { get; set; }
    }
}