using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Tyler.Views
{
    public class VisibleWhenValueConverter : IValueConverter
    {
        public bool Value { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, Value) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}