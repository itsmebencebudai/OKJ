using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskManagerWPF
{
    public class PriorityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string priority = value as string;
            return priority switch
            {
                "High" => Brushes.Red,
                "Medium" => Brushes.Orange,
                "Low" => Brushes.Green,
                _ => Brushes.Black,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
