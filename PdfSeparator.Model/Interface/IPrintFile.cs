using System.Collections.Generic;

namespace PdfSeparator.Model.Interface
{
    public interface IPrintFile
    {
        List<int> Pages { get; }
        string Name { get; }
    }
}