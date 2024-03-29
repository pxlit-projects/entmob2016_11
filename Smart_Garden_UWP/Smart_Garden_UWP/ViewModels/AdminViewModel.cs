﻿using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP_Models;
using System;
using System.ComponentModel;

namespace Smart_Garden_UWP.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private IUserService userService;
        private ICropService cropService;
        private INavigationService navigationService;
        private User user;

        #region Properties of the ViewModel
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

        public AdminViewModel(IUserService userService, INavigationService navigationService, ICropService cropService)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.cropService = cropService;

            Messenger.Default.Register<User>(this, OnUserReceived);

            LoadCommands();
        }

        #region Commands Section
        public CustomCommand LogOutCommand { get; set; }
        public CustomCommand ShowUserManagementCommand { get; set; }
        public CustomCommand ShowCropManagementCommand { get; set; }

        private void LoadCommands()
        {
            LogOutCommand = new CustomCommand(LogOut, CanExecute);
            ShowUserManagementCommand = new CustomCommand(ShowUserManagement, CanExecute);
            ShowCropManagementCommand = new CustomCommand(ShowCropManagement, CanExecute);
        }

        private void ShowCropManagement(object obj)
        {
            navigationService.NavigateTo("CropManagement");
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private void ShowUserManagement(object obj)
        {
            navigationService.NavigateTo("UserManagement");
        }

        private void LogOut(object obj)
        {
            navigationService.NavigateTo("Logout");
        }
        #endregion

        #region Messenger Section
        private void OnUserReceived(User user)
        {
            User = user;
        }
        #endregion
    }
}