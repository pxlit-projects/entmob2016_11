using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace Smart_Garden.SensorTag
{
    public class GattDeviceCollection: INotifyPropertyChanged
    {
        DeviceInformation device;

        public event PropertyChangedEventHandler PropertyChanged;

        public GattDeviceCollection(DeviceInformation device)
        {
            this.device = device;
        }

        private HumiditySensor humidity;
        public HumiditySensor Humidity {
            get { return humidity;  }
            set { humidity = value; humidity.PropertyChanged += Humidity_PropertyChanged; }
        }

        private void Humidity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Humidity"));
        }

        private IRTemperatureSensor irTemperature;
        public IRTemperatureSensor IRTemperature
        {
            set { irTemperature = value; irTemperature.PropertyChanged += IrTemperature_PropertyChanged; }
            get { return irTemperature; }
        }

        private void IrTemperature_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IRTemperature"));
        }

        public DeviceInfo Info { get; set; }

        private LightSensor light;
        public LightSensor Light {
            get { return light; }
            set { light = value; light.PropertyChanged += Light_PropertyChanged; }
        }

        private void Light_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Light"));
        }

        public string DeviceID
        {
            get
            {
                return device.Id;
            }
        }
    }
}
