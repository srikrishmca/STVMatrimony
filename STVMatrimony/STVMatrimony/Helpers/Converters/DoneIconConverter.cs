using System;
using System.Globalization;
using Xamarin.Forms;

namespace STVMatrimony.Helpers.Converters
{
    public class DoneIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDone = (bool)value;
            return isDone ? "\uf058" : "\uf111";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
