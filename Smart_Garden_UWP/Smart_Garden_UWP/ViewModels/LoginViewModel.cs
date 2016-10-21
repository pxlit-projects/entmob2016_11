using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart_Garden_UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
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

        public LoginViewModel()
        {
            LoadCommands();
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
            UserService userService = new UserService();
            string str = await userService.getAllUsers();
            if (str != null)
                Debug.WriteLine(str);
        }
    }
}