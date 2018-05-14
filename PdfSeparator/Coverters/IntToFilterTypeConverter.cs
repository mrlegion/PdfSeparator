using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PdfSeparator.Model.Common;

namespace PdfSeparator.Coverters
{
    public class IntToFilterTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (FilterType)Enum.ToObject(typeof(FilterType), value ?? throw new ArgumentNullException(nameof(value)));
        }
    }
}