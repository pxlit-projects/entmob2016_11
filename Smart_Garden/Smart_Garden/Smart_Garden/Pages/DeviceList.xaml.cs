﻿using Robotics.Mobile.Core.Bluetooth.LE;
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
        IAdapter adapter;
        ObservableCollection<IDevice> devices;
        public DeviceList(IAdapter adapter)
        {
            InitializeComponent();

            this.adapter = adapter;
            this.devices = new ObservableCollection<IDevice>();
            listView.ItemsSource = devices;
            List<String> IDs = new List<String>();

            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) => {
                Device.BeginInvokeOnMainThread(() => {
                    if (!IDs.Contains(e.Device.ID.ToString()))
                    {
                        IDs.Add(e.Device.ID.ToString());
                        devices.Add(e.Device);
                    }
                });
            };
            adapter.ScanTimeoutElapsed += (sender, e) => {
                adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
                Device.BeginInvokeOnMainThread(() => {
                    IsBusy = false;
                    DisplayAlert("Timeout", "Bluetooth scan timeout elapsed", "OK");
                });
            };

            ScanAllButton.Clicked += (sender, e) => {
                InfoFrame.IsVisible = false;
                StartScanning();
            };

        }
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
            {
                return;
            }
            Debug.WriteLine(" xxxxxxxxxxxx  OnItemSelected " + e.SelectedItem.ToString());
            IsBusy = false;
            StopScanning();

            var device = e.SelectedItem as IDevice;
            var servicePage = new ServiceList(adapter, device);
            // load services on the next page
            Navigation.PushAsync(servicePage);

            ((ListView)sender).SelectedItem = null; // clear selection
        }

        void StartScanning()
        {
            IsBusy = true;
            StartScanning(Guid.Empty);
        }
        void StartScanning(Guid forService)
        {

            if (adapter.IsScanning)
            {
                IsBusy = false;
                adapter.StopScanningForDevices();
                Debug.WriteLine("StartScanning > adapter.StopScanningForDevices()");
            }
            else
            {
                devices.Clear();
                IsBusy = true;
                adapter.StartScanningForDevices(forService);
                Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
            }
        }

        void StopScanning()
        {
            // stop scanning
            new Task(() => {
                if (adapter.IsScanning)
                {
                    IsBusy = false;
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }
    }
}