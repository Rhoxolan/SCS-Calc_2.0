using SCSCalc.Parameters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace SCS_Calc_2._0.Converters
{
    public class RecommendationToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<ConnectionInterfaceStandard>)
            {
                return (value as ICollection<ConnectionInterfaceStandard>)!.Contains((ConnectionInterfaceStandard)parameter);
            }
            return Equals(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }

        public static RecommendationToBooleanConverter Instance { get; } = new();
    }
}
