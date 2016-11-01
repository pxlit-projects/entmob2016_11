using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP.Services;
using System;
using System.ComponentModel;
using Smart_Garden_UWP_Models;
using SmarT_Garden_UWP_Models.Models;

namespace Smart_Garden_UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private UserService userService;
        private NavigationService navigationService;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public CustomCommand LoginCommand { get; set; }

        public LoginViewModel(UserService userService, NavigationService navigationService)
        {
            LoadCommands();
            this.userService = userService;
            this.navigationService = navigationService;
        }

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
                    //navigate
                    Messenger.Default.Send<User>(user);
                    navigationService.NavigateTo("Admin");
                }
                else
                {
                    navigationService.NavigateTo("User");
                }
            }
        }

        private Boolean checkLogin(User user)
        {
            if(user != null && user.Password.Equals(Password))
            {
                return true;
            }

            return false;
        }
    }
}