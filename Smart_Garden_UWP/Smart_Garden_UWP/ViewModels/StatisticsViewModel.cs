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

        #region Properties of the viewmodel
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
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
     
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        public StatisticsViewModel(UserService userService, NavigationService navigationService, CropService cropService, SensorService sensorService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.cropService = cropService;
            this.sensorService = sensorService;

            LoadCommands();
        }

        #region Commands section
        private void LoadCommands()
        {
            LogOutCommand = new CustomCommand(LogOut, CanLogOut);
        }

        public CustomCommand LogOutCommand { get; set; }

        private bool CanLogOut(object obj)
        {
            return true;
        }

        private void LogOut(object obj)
        {
            navigationService.NavigateTo("Logout");
        }
        #endregion
    }
}