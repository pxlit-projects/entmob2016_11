using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.ViewModels
{
    public class DeviceItemViewModel
    {
        public IDevice Device { get; set; }

        public Guid Id => Device.Id;
        public bool IsConnected => Device.State == DeviceState.Connected;
        public int Rssi => Device.Rssi;
        public string Name => Device.Name;

        public DeviceItemViewModel(IDevice device)
        {
            Device = device;
        }
    }
}
