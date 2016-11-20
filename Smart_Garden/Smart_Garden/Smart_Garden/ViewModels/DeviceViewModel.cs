﻿using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Plugin.BLE.Abstractions.Exceptions;
using Smart_Garden.Models;
using Smart_Garden.Pages;
using Smart_Garden.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smart_Garden.ViewModels
{
    public class DeviceViewModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        private IBluetoothLE ble;
        private User user;
        private IAdapter adapter;
        private string _bleStatus;
        private ObservableCollection<DeviceItemViewModel> _deviceList = new ObservableCollection<DeviceItemViewModel>();

        public Command StartScanCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string bleStatus)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(bleStatus));
        }

        public DeviceViewModel(User user, IAdapter adapter, IBluetoothLE ble, INavigation navigation)
        {
            this.ble = ble;
            this.user = user;
            this.adapter = adapter;
            this.navigation = navigation;
            _bleStatus = GetStateText();
            ble.StateChanged += OnStateChanged;
            StartScanCommand = new Command(StartScan);

        }
        private void OnStateChanged(object sender, BluetoothStateChangedArgs e)
        {
            BleStatus = GetStateText();
        }

        private async void StartScan()
        {
            _deviceList.Clear();
            try
            {
                adapter.DeviceDiscovered += (s, a) => _deviceList.Add(new DeviceItemViewModel(a.Device));
                await adapter.StartScanningForDevicesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error StartScan : " + ex);
            }
        }

        public string BleStatus
        {
            get { return _bleStatus; }
            set
            {
                _bleStatus = value;
                OnPropertyChanged(nameof(BleStatus));
            }
        }
        public ObservableCollection<DeviceItemViewModel> DeviceList
        {
            get { return _deviceList; }
            set
            {
                _deviceList = value;
                OnPropertyChanged(nameof(DeviceList));
            }
        }

        public async void HandleSelectedDevice(DeviceItemViewModel device)
        {
            if (await ConnectDeviceAsync(device))
            {
                MessagingCenter.Subscribe<string>(this, "senddevice", (arg) => {
                    MessagingCenter.Send(device, "connectdevice");
                });
                await adapter.StopScanningForDevicesAsync();
                /*await navigation.PushAsync(new ServiceListPage()
                {
                    Title = "StrongPlate"
                });
                */

            }
        }

        public async Task<bool> ConnectDeviceAsync(DeviceItemViewModel device)
        {
            try
            {
                await adapter.ConnectToDeviceAsync(device.Device);
            }
            catch (DeviceConnectionException ex)
            {
                Debug.WriteLine("Error ConnectDeviceAsync : " + ex);
            }
            return true;
        }

        public DeviceItemViewModel SelectedDevice
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    HandleSelectedDevice(value);
                }

            }
        }

        private string GetStateText()
        {
            switch (ble.State)
            {
                case BluetoothState.Unknown:
                    return "Unknown BLE state.";
                case BluetoothState.Unavailable:
                    return "BLE is not available on this device.";
                case BluetoothState.Unauthorized:
                    return "You are not allowed to use BLE.";
                case BluetoothState.TurningOn:
                    return "BLE is warming up, please wait.";
                case BluetoothState.On:
                    return "BLE is on.";
                case BluetoothState.TurningOff:
                    return "BLE is turning off. That's sad!";
                case BluetoothState.Off:
                    return "BLE is off. Turn it on!";
                default:
                    return "Unknown BLE state.";
            }
        }
    }
}
