using System;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Smart_Garden.SensorTag;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Smart_Garden.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SensorTagFeedPage : Page
    {
        int sensorCount = 0;

        public SensorTagFeedPage()
        {
            this.InitializeComponent();

        }

        DeviceInformation device;
        BluetoothLEDevice leDevice;
        DeviceWatcher watcher;
        GattDeviceCollection devices;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += DevicePage_BackRequested;
            device = e.Parameter as DeviceInformation;
            devices = new GattDeviceCollection(device);

            leDevice = await BluetoothLEDevice.FromIdAsync(device.Id);
            string selector = "(System.DeviceInterface.Bluetooth.DeviceAddress:=\"" + leDevice.BluetoothAddress.ToString("X") + "\")";

            watcher = DeviceInformation.CreateWatcher(selector);
            watcher.Added += Watcher_Added;
            watcher.Removed += Watcher_Removed;
            watcher.Start();

            base.OnNavigatedTo(e);
        }

        private void Watcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            //throw new NotImplementedException();
        }

        private async void Watcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    try
                    {
                        var dev = await GattDeviceService.FromIdAsync(args.Id);
                        if (dev != null)
                        {
                            switch (dev.Uuid.ToString())
                            {
                                case SensorsUId.UUID_HUM_SERV:
                                    devices.Humidity = new HumiditySensor(dev);
                                    await devices.Humidity.EnableSensor();
                                    await devices.Humidity.EnableNotifications();
                                    sensorCount++;
                                    break;
                                case SensorsUId.UUID_IRT_SERV:
                                    devices.IRTemperature = new IRTemperatureSensor(dev);
                                    await devices.IRTemperature.EnableSensor();
                                    await devices.IRTemperature.EnableNotifications();
                                    sensorCount++;
                                    break;
                                case SensorsUId.UUID_INF_SERV:
                                    devices.Info = new DeviceInfo(dev);
                                    await devices.Info.Initialize();
                                    sensorCount++;
                                    break;
                                case SensorsUId.UUID_OPT_SERV:
                                    devices.Light = new LightSensor(dev);
                                    await devices.Light.EnableSensor();
                                    await devices.Light.EnableNotifications();
                                    sensorCount++;
                                    break;
                            }
                            if (sensorCount == 4)
                            {
                                await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                () =>
                                {
                                    progress.Visibility = Visibility.Collapsed;
                                    this.DataContext = devices;
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
        }

        private void DevicePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            watcher.Stop();
            base.OnNavigatedFrom(e);
        }
    }
}

