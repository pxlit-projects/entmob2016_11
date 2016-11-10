
using Smart_Garden.Pages;
using Smart_Garden.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Services
{
    public class NavigationService : INavigationService
    {
        private Xamarin.Forms.INavigation _navigation;
        public NavigationService()
        {
            _navigation = Xamarin.Forms.DependencyService.Get<Xamarin.Forms.INavigation>();
        }
        public void NavigateTo(string key)
        {
            switch (key)
            {
                case "Device":
                    var devicePage = new DeviceList();
                    // load services on the next page
                    _navigation.PushAsync(devicePage);
                    break;
            }
        }
    }
}
