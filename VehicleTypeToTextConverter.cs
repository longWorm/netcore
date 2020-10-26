using System;
using System.Windows.Data;

namespace netcore
{
    class VehicleTypeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VehicleType type = (VehicleType)value;
            switch (type)
            {
                case VehicleType.Car:
                    return "Car";
                case VehicleType.Boat:
                    return "Boat";
                default:
                    return "undefined";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int ret = 0;
            return int.TryParse((string)value, out ret) ? ret : 0;
        }
    }
}
