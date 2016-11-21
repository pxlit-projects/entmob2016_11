using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Models;
using Smart_Garden.Pages;
using Smart_Garden.Repository;
using Smart_Garden.Repository.Interfaces;
using Smart_Garden.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smart_Garden.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IAdapter adapter;
        private IBluetoothLE ble;
        private INavigation navigation;
        private UserService userService;
        private String username;
        private String password;
        public Command LoginCommand { get; }
        public LoginViewModel(IAdapter adapter, IBluetoothLE ble, INavigation navigation)
        {
            this.adapter = adapter;
            this.ble = ble;
            this.userService = new UserService();
            this.navigation = navigation;
            LoginCommand = new Command(Login);
        }
        #region INotifyPropertyChanged Implementation
        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        #region Properties of the viewmodel


        public IAdapter Adapter
        {
            get
            {
                return adapter;
            }
            set
            {
                adapter = value;
                NotifyPropertyChanged("Adapter");
   
            }
        }

        public UserService UserService
        {
            get
            {
                return userService;
            }

            set
            {
                userService = value;
            }
        }

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
            }
        }

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
            }
        }
        #endregion 



        public async void Login(object obj)
        {
             
            User user = await userService.getUserByUsername(Username);
             
            

            if (checkLogin(user))
            {
                if (user.Role.FindIndex(x => x.Role.Equals("ROLE_ADMIN")) != -1)
                {
                    //navigate

                    await navigation.PushAsync(new DeviceList(user, adapter, ble)
                    {
                        Title = "Devices"
                    });
                }
                else
                {
                    //navigationService.NavigateTo("User");
                }
            }
        }
        

        #region Helper methods
        private Boolean checkLogin(User user)
        {
            if (user != null && user.Password.Equals(Password))
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}
