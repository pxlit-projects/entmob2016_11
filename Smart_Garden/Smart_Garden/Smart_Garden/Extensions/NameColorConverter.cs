using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smart_Garden.Extensions
{
    public class NameColorConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            String name = (String)value;
            if (String.IsNullOrEmpty(name))
                return Color.Gray;
            else
                return name.Contains("Sensor") ? Color.Red : Color.Black;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException("NameColorConverter is one-way");
        }
    }
}
