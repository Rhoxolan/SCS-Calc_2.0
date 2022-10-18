using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SCS_Calc_2._0.Converters
{
    public class TextLengthToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((int)value > 1)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
