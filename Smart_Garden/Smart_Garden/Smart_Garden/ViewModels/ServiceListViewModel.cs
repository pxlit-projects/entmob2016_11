using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Models;
using Smart_Garden.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smart_Garden.ViewModels
{
    public class ServiceListViewModel : INotifyPropertyChanged
    {
        private IDevice device;
        private UserService service;
        private bool isRunning;
        private User user;
        private double temperatureData;
        private double humidityData;
        private double lightData;
        List<KeyValuePair<string, ICharacteristic>> characteristics = new List<KeyValuePair<string, ICharacteristic>>();
        public ServiceListViewModel(User user)
        {
            this.user = user;
            isRunning = true;
            service = new UserService();
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(5000);
                while (isRunning)
                {
                    isRunning = await AddEntity();
                    await Task.Delay(10000);    
                }
            });
            MessagingCenter.Subscribe<DeviceItemViewModel>(this, "connectdevice", (arg) =>
            {
                this.device = arg.Device;
                GetServices();
            });
            MessagingCenter.Send("true", "senddevice");
        }

        //TestingPurpose
        public ServiceListViewModel(User user, UserService userService)
        {
            this.user = user;
            this.service = userService;
        }
        private async void GetServices()
        {
            await GetTempService();
            await GetHumidityService();
            await GetLightService();
            
            await readTemp();
            await readHumidity();
            await readLight();
        }
        #region PropertyChanged impl
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string temperature)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(temperature));
        }
        #endregion
        #region Properties
        public double TemperatureData
        {
            get { return temperatureData; }
            set
            {
                temperatureData = value;
                onPropertyChanged(nameof(TemperatureData));
            }
        }
        
        public double LightData
        {
            get { return lightData; }
            set
            {
                lightData = value;
                onPropertyChanged(nameof(LightData));
            }
        }
        
        public double HumidityData
        {
            get { return humidityData; }
            set
            {
                humidityData = value;
                onPropertyChanged(nameof(HumidityData));
            }
        }
        
        #endregion
        #region DataConverters
        public double AmbientData(byte[] bytes)
        {

            var ambientTemp = (UInt16) BitConverter.ToUInt16(bytes, 2) / 128.0;
            return ambientTemp;
        }

        private double CalculateHumidityInPercent(byte[] sensorData)
        {
            int hum = BitConverter.ToUInt16(sensorData, 2);

            hum = hum - (hum % 4);

            return (-6f) + 125f * (hum / 65535f);
        }

        private double CalculateLight(byte[] data)
        {
            int mantissa;
            int exponent;
            ushort sfloat = BitConverter.ToUInt16(data, 0);

            mantissa = sfloat & 0x0FFF;
            exponent = (sfloat >> 12) & 0xFF;

            double output;
            double magnitude = Math.Pow(2.0f, exponent);
            output = (mantissa * magnitude);

            return output / 100.0f;
        }

        #endregion
        #region services

        private async Task GetTempService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa00-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa01-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa02-0451-4000-b000-000000000000"));
                characteristics.Add(new KeyValuePair<String, ICharacteristic >("tempData", dataCharacteristic));
                await configCharacteristic.WriteAsync(new byte[] { 0x01 });



            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getTempService: " + ex);
            }
        }
        private async Task GetHumidityService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa20-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa21-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa22-0451-4000-b000-000000000000"));
                characteristics.Add(new KeyValuePair<String, ICharacteristic>("humidData", dataCharacteristic));
                await configCharacteristic.WriteAsync(new byte[] { 0x01 });

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getHumidityService: " + ex);
            }
        }
        
        private async Task GetLightService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa70-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa71-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa72-0451-4000-b000-000000000000"));
                characteristics.Add(new KeyValuePair<String, ICharacteristic>("lightData", dataCharacteristic));
                await configCharacteristic.WriteAsync(new byte[] { 0x01 });

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getLightService: " + ex);
            }
        }
        
        #endregion
        #region Readers
        private async Task readTemp()
        {
            ICharacteristic characteristic = null;
            for (int i = 0; i < characteristics.Count; i++)
            {
                if (characteristics[i].Key.Equals("tempData"))
                {
                    characteristic = characteristics[i].Value;
                }
            }

            characteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;             
                temperatureData = AmbientData(bytes);

                onPropertyChanged(nameof(TemperatureData));
            };
            await characteristic.StartUpdatesAsync();
        }
        
        private async Task readLight()
        {
            ICharacteristic characteristic = null;
            for (int i = 0; i < characteristics.Count; i++)
            {
                if (characteristics[i].Key.Equals("lightData"))
                {
                    characteristic = characteristics[i].Value;
                }
            }

            characteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;
                lightData = CalculateLight(bytes);
                onPropertyChanged(nameof(LightData));
            };
            await characteristic.StartUpdatesAsync();
        }
        

        private async Task readHumidity()
        {
            ICharacteristic characteristic = null;
            for (int i = 0; i < characteristics.Count; i++)
            {
                if (characteristics[i].Key.Equals("humidData"))
                {
                    characteristic = characteristics[i].Value;
                }
            }

            characteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;
                humidityData = CalculateHumidityInPercent(bytes);
                onPropertyChanged(nameof(HumidityData));
            };
            await characteristic.StartUpdatesAsync();
        }
        
        #endregion

        public async Task<bool> AddEntity()
        {
            try
            {
                Sensor sensor = new Sensor()
                {
                    above = true,
                    Humid = humidityData,
                    Light = lightData,
                    Temp = temperatureData,
                };
                user.Sensors.Add(sensor);
                return await service.addSensorToUser(user);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
