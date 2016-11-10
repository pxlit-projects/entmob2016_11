using Robotics.Mobile.Core.Bluetooth.LE;
using Smart_Garden.Models;
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

        public DeviceList()
        {
            InitializeComponent();
        }
        /*
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
        */
    }
}
