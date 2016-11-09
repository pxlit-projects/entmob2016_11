using Robotics.Mobile.Core.Bluetooth.LE;
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

        public App(IAdapter Adapter)
        {
            InitializeComponent();
            var np = new NavigationPage(new Login());
            if (Device.OS != TargetPlatform.iOS)
            {
                // we manage iOS themeing via the native app Appearance API
                np.BarBackgroundColor = Color.Red;
            }
            MainPage = np;
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
