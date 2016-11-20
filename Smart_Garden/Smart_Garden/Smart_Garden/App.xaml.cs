using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Smart_Garden
{
    public partial class App : Application
    {
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        IBluetoothLE ble = CrossBluetoothLE.Current;

        public App()
        {
            InitializeComponent();

            NavigationPage navigation = new NavigationPage(new Login(adapter, ble)
            {
                Title = "StrongPlate"
            });
            MainPage = navigation;
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
