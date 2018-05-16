namespace PdfSeparator.Model.Common
{
    public enum SeparateType
    {
        /// <summary>
        /// Делить файл по стилю: один файл на один формат
        /// </summary>
        InOneFile = 0,

        /// <summary>
        /// Делить файл по стилю: каджый формат последовательно в отдельном файле
        /// </summary>
        EachInSeparateFile = 1,
    }
}