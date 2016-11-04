using Smart_Garden_UWP.Utilities;
using System;
using System.ComponentModel;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP.Services.Interfaces;

namespace Smart_Garden_UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IUserService userService;
        private INavigationService navigationService;

        #region Properties of the viewmodel
        private String username;
        public String Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                NotifyPropertyChanged("Username");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private String password;
        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                NotifyPropertyChanged("Password");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion 

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        public LoginViewModel(IUserService userService, INavigationService navigationService)
        {
            LoadCommands();
            this.userService = userService;
            this.navigationService = navigationService;
        }

        #region Commands Section
        public CustomCommand LoginCommand { get; set; }

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, CanLogin);
        }

        private bool CanLogin(object obj)
        {
            //if(!String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(Username))
            //{
            //    return true;
            //}
            return true;
        }

        private async void Login(object obj)
        {
            User user = await userService.getUserByUsername(Username);

            if (checkLogin(user))
            {
                if (user.Role.FindIndex(x => x.Role.Equals("ROLE_ADMIN")) != -1)
                {
                    //navigate + send logged in user
                    Messenger.Default.Send<User>(user);
                    navigationService.NavigateTo("Admin");
                }
                else
                {
                    navigationService.NavigateTo("User");
                }
            }
        }
        #endregion

        #region Helper methods
        private Boolean checkLogin(User user)
        {
            if(user != null && user.Password.Equals(Password))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}