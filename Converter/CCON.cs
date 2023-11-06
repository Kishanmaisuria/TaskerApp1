using System.Globalization;

namespace TaskerApp.Converter
{
    internal class CCON : IValueConverter
    {
        //converts color string to actual
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value.ToString();
            return Color.FromArgb(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
