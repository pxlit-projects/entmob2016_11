using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP
{
    public class ViewModelLocator
    {
        private static LoginViewModel loginViewModel = new LoginViewModel(new UserService(), new NavigationService());
        private static AdminViewModel adminViewModel = new AdminViewModel(new UserService(), new NavigationService(), new CropService());
        private static StatisticsViewModel statisticsViewModel = new StatisticsViewModel(new UserService(), new NavigationService(), new CropService(), new SensorService());

        public static LoginViewModel LoginViewModel
        {
            get
            {
                return loginViewModel;
            }
        }

        public static StatisticsViewModel StatisticsViewModel
        {
            get
            {
                return statisticsViewModel;
            }
        }

        public static AdminViewModel AdminViewModel
        {
            get
            {
                return adminViewModel;
            }
        }
    }
}