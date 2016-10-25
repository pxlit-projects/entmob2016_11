using Smart_Garden_UWP.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Smart_Garden_UWP.Services
{
    public class NavigationService
    {
        public void NavigateTo(string key)
        {
            if (key == "Admin")
            {
                AdminPage page = new AdminPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(AdminPage));
            }

            if(key == "User")
            {
                StatisticsPage page = new StatisticsPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(StatisticsPage));
            }

            if(key == "Logout")
            {
                LoginPage page = new LoginPage();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(LoginPage));
            }
        }

    }
}
