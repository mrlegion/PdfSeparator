using System;
using System.Collections.Generic;
using System.Windows.Media;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Common
{
    public class Page : IPage
    {
        public double Width { get; set; }
        public double Heigth { get; set; }
        public int Position { get; set; }
        public string Format { get; set; }
        public PageOrientation Orientation { get; set; }

        public Page(double width, double heigth, int position)
        {
            Width = ConvertPtToMm(value: width);
            Heigth = ConvertPtToMm(value: heigth);
            Position = position;
            Orientation = CheckPageOrientation();
            Format = GetFormatName();
        }

        private PageOrientation CheckPageOrientation() =>
            Width > Heigth ? PageOrientation.Horizontal : PageOrientation.Vertical;

        private double ConvertPtToMm(double value) => value * 0.3528;

        private string GetFormatName()
        {
            string result = null;

            // TODO: Переместить этот кастыль в другое место
            var formats = new Dictionary<string, int[]>()
            {
                { "a3", new[] { 420, 297, 124740, 121180, 128350}},
                { "a4", new[] { 297, 210, 62370,  59860,  64930 }},
                { "a5", new[] { 210, 148, 31080,  29315,  32895 }},
            };

            var area = Width * Heigth;

            foreach (var format in formats)
            {
                if (area.CompareTo(format.Value[3]) == 1 && area.CompareTo(format.Value[4]) == -1)
                {
                    bool widthCompateTo = false;
                    bool heightCompateTo = false;

                    switch (Orientation)
                    {
                        case PageOrientation.Vertical:
                            widthCompateTo = CompareTo(value: Width, compare: format.Value[1]);
                            heightCompateTo = CompareTo(value: Heigth, compare: format.Value[0]);
                            break;
                        case PageOrientation.Horizontal:
                            widthCompateTo = CompareTo(value: Width, compare: format.Value[0]);
                            heightCompateTo = CompareTo(value: Heigth, compare: format.Value[1]);
                            break;
                    }

                    if (!widthCompateTo || !heightCompateTo) continue;

                    Width = Orientation == PageOrientation.Vertical ? format.Value[1] : format.Value[0];
                    Heigth = Orientation == PageOrientation.Vertical ? format.Value[0] : format.Value[1];
                    result = format.Key;
                }
            }

            return result ?? $"{Math.Floor(Width)} x {Math.Floor(Heigth)}";
        }


        public bool CompareTo(double value, double compare)
        {
            return value.CompareTo(compare - 5) > 0 && value.CompareTo(compare + 5) < 0;
        }
    }
}