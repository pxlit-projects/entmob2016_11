using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace Smart_Garden.SensorTag
{
    public class DeviceCollection
    {
        public ObservableCollection<DeviceInformation> SensorTags { get; set; }

        public DeviceCollection()
        {
            SensorTags = new ObservableCollection<DeviceInformation>();
        }
    }
}
