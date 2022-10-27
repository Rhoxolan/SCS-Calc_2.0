using System;
using System.Globalization;
using System.Windows.Data;

namespace SCS_Calc_2._0.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            return $"{dateTime.ToShortDateString()} {dateTime.ToLongTimeString()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public static DateTimeToStringConverter Instance { get; } = new();
    }
}
