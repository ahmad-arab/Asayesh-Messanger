﻿

using System;
using System.Globalization;
using System.Windows.Media;

namespace AsayeshMessenger
{
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
            }
            catch
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#FFFFFF"));
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
