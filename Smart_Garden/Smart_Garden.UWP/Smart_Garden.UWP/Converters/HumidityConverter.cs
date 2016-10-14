using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Smart_Garden.SensorTag;

namespace Smart_Garden.UWP.Converters
{
    public class HumidityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = value as HumiditySensor;
            return String.Format($"{item.HumidityData:n2} %rH");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
