using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP_Models;
using System;
using System.ComponentModel;

namespace Smart_Garden_UWP.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private IUserService userService;
        private ICropService cropService;
        private INavigationService navigationService;
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

        public StatisticsViewModel(IUserService userService, INavigationService navigationService, ICropService cropService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.cropService = cropService;

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