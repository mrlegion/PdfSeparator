using PdfSeparator.Model.Common;

namespace PdfSeparator.Model.Interface
{
    public interface IPage
    {
        double Width { get; set; }
        double Heigth { get; set; }
        int Position { get; set; }
        string Format { get; set; }
        PageOrientation Orientation { get; set; }
    }
}