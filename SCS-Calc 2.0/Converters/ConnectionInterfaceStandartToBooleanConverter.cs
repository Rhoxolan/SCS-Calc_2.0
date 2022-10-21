using System;
using System.Globalization;
using System.Windows.Data;

namespace SCS_Calc_2._0.Converters
{
    public class ConnectionInterfaceStandartToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
            {
                return parameter;
            }
            return false;
        }
    }
}
