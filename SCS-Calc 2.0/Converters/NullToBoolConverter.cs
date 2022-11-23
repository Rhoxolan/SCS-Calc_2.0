using System;
using System.Globalization;
using System.Windows.Data;

namespace SCSCalc_2_0.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Equals(value, false))
            {
                return null!;
            }
            return default!;
        }

        public static NullToBoolConverter Instance { get; } = new();
    }
}
