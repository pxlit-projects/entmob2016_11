using Smart_Garden.SensorTag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Smart_Garden.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DeviceWatcher sensorWatch;
        DeviceCollection sensorList = new DeviceCollection();

        public MainPage()
        {
            this.InitializeComponent();    
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            sensorList.SensorTags.Clear();
            sensorListView.ItemsSource = sensorList.SensorTags;

            sensorWatch = DeviceInformation.CreateWatcher(
                "System.ItemNameDisplay:~~\"SensorTag\"",
                new string[] { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" },
                DeviceInformationKind.AssociationEndpoint);

            sensorWatch.Added += DeviceWatcher_Added;
            sensorWatch.Removed += DeviceWatcher_Removed;
            sensorWatch.Start();

            base.OnNavigatedTo(e);
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            sensorWatch.Stop();
            base.OnNavigatedFrom(e);
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                var el = (from a in sensorList.SensorTags where a.Id.Equals(args.Id) select a).FirstOrDefault();
                if (el != null)
                    sensorList.SensorTags.Remove(el);
            });
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    sensorList.SensorTags.Add(args);
                });
        }

        private async void sensorListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as DeviceInformation;
            if (item.Pairing.CanPair)
            {
                var result = await item.Pairing.PairAsync();

                if ((result.Status == DevicePairingResultStatus.Paired) || (result.Status == DevicePairingResultStatus.AlreadyPaired))
                {
                    this.Frame.Navigate(typeof(SensorTagFeedPage), item);
                }
            }
            else if (item.Pairing.IsPaired)
            {
                this.Frame.Navigate(typeof(SensorTagFeedPage), item);
            }
        }
    }
}
