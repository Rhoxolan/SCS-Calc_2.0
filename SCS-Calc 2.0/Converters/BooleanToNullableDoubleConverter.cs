using System;
using System.Globalization;
using System.Windows.Data;

namespace SCS_Calc_2._0.Converters
{
    public class BooleanToNullableDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
            {
                return null!;
            }
            return Binding.DoNothing;
        }

        public static BooleanToNullableDoubleConverter Instance { get; } = new();
    }
}
