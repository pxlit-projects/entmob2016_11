﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Smart_Garden.SensorTag;

namespace Smart_Garden.UWP.Converters
{
    public class IRAmbientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = value as IRTemperatureSensor;
            return String.Format($"{item.AmbientTemperature:n2} {'\u00b0'}C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
