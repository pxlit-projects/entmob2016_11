using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP_Models;
using System;
using System.ComponentModel;

namespace Smart_Garden_UWP.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private UserService userService;
        private CropService cropService;
        private NavigationService navigationService;
        private SensorService sensorService;
        private User user;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomCommand LogOutCommand { get; set; }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public StatisticsViewModel(UserService userService, NavigationService navigationService, CropService cropService, SensorService sensorService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.cropService = cropService;
            this.sensorService = sensorService;

            LoadCommands();
        }

        private void LoadCommands()
        {
            LogOutCommand = new CustomCommand(LogOut, CanLogOut);
        }

        private bool CanLogOut(object obj)
        {
            return true;
        }

        private void LogOut(object obj)
        {
            navigationService.NavigateTo("Logout");
        }
    }
}