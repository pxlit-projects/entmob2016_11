using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Models;
using Smart_Garden.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smart_Garden.Pages
{
    public partial class DeviceList : ContentPage
    {

        public DeviceList(User user, IAdapter adapter, IBluetoothLE ble )
        {
            InitializeComponent();
            DeviceViewModel deviceViewmodel = new DeviceViewModel(user, adapter, ble, Navigation);
            BindingContext = deviceViewmodel;
        }
    }
}
