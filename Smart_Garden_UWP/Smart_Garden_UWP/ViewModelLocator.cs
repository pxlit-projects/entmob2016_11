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
        private static LoginViewModel loginViewModel = new LoginViewModel();
        private static AdminViewModel adminViewModel = new AdminViewModel();
        private static StatisticsViewModel statisticsViewModel = new StatisticsViewModel();

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