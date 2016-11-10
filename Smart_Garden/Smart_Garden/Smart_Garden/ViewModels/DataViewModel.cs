using Robotics.Mobile.Core.Bluetooth.LE;
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
    public class DataViewModel : INotifyPropertyChanged
    {
        private User user;
        private IAdapter adapter;
        private bool hideFrame;
        ObservableCollection<IDevice> devices;
        public DataViewModel()
        {
            try
            {

                MessagingCenter.Subscribe<Login, IAdapter>(this, "adapter", (sender, arg) =>
                {
                    Adapter = arg;
                });
                MessagingCenter.Subscribe<Login, User>(this, "user", (sender, arg) =>
                {
                    User = arg;
                });
            }
            catch(Exception ex)
            {
                String exception = ex.StackTrace;
                exception = ex.Message;
            }


            HideFrame = true;
            LoadCommands();

            devices = new ObservableCollection<IDevice>();
            List<String> IDs = new List<String>();
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) => {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    if (!IDs.Contains(e.Device.ID.ToString()))
                    {
                        IDs.Add(e.Device.ID.ToString());
                        devices.Add(e.Device);
                    }
                });
            };
            adapter.ScanTimeoutElapsed += (sender, e) => {
                adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    App.Current.MainPage.DisplayAlert("Timeout", "Bluetooth scan timeout elapsed", "OK");
                });
            };
        }
        #region Properties
        public ObservableCollection<IDevice> Devices
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
                NotifyPropertyChanged("Devices");
            }
        }

        public IAdapter Adapter
        {
            get
            {
                return adapter;
            }
            set
            {
                adapter = value;
                NotifyPropertyChanged("Adapter");
            }
        }
        public bool HideFrame
        {
            get
            {
                return hideFrame;
            }
            set
            {
                hideFrame = value;
                NotifyPropertyChanged("HideFrame");
            }
        }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }
        #endregion

        #region Commands Section
        public CustomCommand ScanCommand { get; set; }

        private void LoadCommands()
        {
            ScanCommand = new CustomCommand(Scan, CanScan);
        }

        private bool CanScan(object obj)
        {

            return true;
        }

        private void Scan(object obj)
        {
            HideFrame = false;
            StartScanning();
        }
        void StartScanning()
        {
            StartScanning(Guid.Empty);
        }
        void StartScanning(Guid forService)
        {

            if (adapter.IsScanning)
            {
                adapter.StopScanningForDevices();
                Debug.WriteLine("StartScanning > adapter.StopScanningForDevices()");
            }
            else
            {
                devices.Clear();
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
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
