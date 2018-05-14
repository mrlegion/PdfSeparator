using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PdfSeparator.Model.Common;

namespace PdfSeparator.Coverters
{
    public class IntToSeparateTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (SeparateType) Enum.ToObject(typeof(SeparateType), value ?? throw new ArgumentNullException(nameof(value)));
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SeparateType)Enum.ToObject(typeof(SeparateType), value ?? throw new ArgumentNullException(nameof(value)));
            //return DependencyProperty.UnsetValue;
        }
    }
}