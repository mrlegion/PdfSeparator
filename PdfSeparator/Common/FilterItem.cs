namespace PdfSeparator.Common
{
    public class FilterItem
    {
        public bool Param1 { get; set; }
        public bool Param2 { get; set; }
        public bool Param3 { get; set; }

        public FilterItem() {}

        public FilterItem(bool param1, bool param2, bool param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }
    }
}
