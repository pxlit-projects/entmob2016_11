using Smart_Garden_UWP.Extensions;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP_Models;
using SmarT_Garden_UWP_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Smart_Garden_UWP.ViewModels
{
    public class UserManagementViewModel : INotifyPropertyChanged
    {
        private IUserService userService;
        private INavigationService navigationService;

        #region Properties of the ViewModel
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
                Error = null;
            }
        }

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
                Error = null;
            }
        }

        private String deleteUsername;
        public String DeleteUsername
        {
            get
            {
                return deleteUsername;
            }

            set
            {
                deleteUsername = value;
                NotifyPropertyChanged("DeleteUsername");
                Error = null;

                if (DeleteUserObj != null)
                {
                    DeleteUserObj = null;
                }
            }
        }

        private ObservableCollection<User> usersList;
        public ObservableCollection<User> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                usersList = value;
                NotifyPropertyChanged("UsersList");
                Error = null;
            }
        }

        private String role;
        public String Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
                Error = null;
            }
        }

        private String filter;
        public String Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                NotifyPropertyChanged("Filter");
                Error = null;
                SelectionChanged();
            }
        }

        private String error;
        public String Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                NotifyPropertyChanged("Error");
            }
        }

        private User deleteUserObj;
        public User DeleteUserObj
        {
            get
            {
                return deleteUserObj;
            }
            set
            {
                deleteUserObj = value;
                NotifyPropertyChanged("DeleteUserObj");
                Error = null;

                if (DeleteUsername != null)
                {
                    DeleteUsername = null;
                }
            }
        }

        public List<string> userFilters = new List<string> { "No filter", "Admins", "Users" };

        public List<String> UserFilters
        {
            get
            {
                return userFilters;
            }
        }

        public List<string> roles = new List<string> { "ROLE_ADMIN", "ROLE_USER" };

        public List<String> Roles
        {
            get
            {
                return roles;
            }
        }
        #endregion

        #region Helper methods
        private async void SelectionChanged()
        {
            if (Filter.Equals("No filter"))
            {
                List<User> temp = await userService.getAllUsers();

                if (temp != null)
                    UsersList = temp.ToObservableCollection();
            }
            else
            {
                List<User> temp = await userService.getAllUsers();

                if (temp != null) {
                    if (Filter.Equals("Admins"))
                    {
                        //only find users which are admin
                        UsersList = temp.FindAll(x => x.Role.FindIndex(c => c.Role.Equals("ROLE_ADMIN")) != -1).ToObservableCollection();
                    }
                    else
                    {
                        //Only find users which are no admin
                        UsersList = temp.FindAll(x => x.Role.FindIndex(c => c.Role.Equals("ROLE_USER")) != -1 && x.Role.FindIndex(c => c.Role.Equals("ROLE_ADMIN")) == -1).ToObservableCollection();
                    }
                }
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

        public UserManagementViewModel(IUserService userService, INavigationService navigationService)
        {
            this.userService = userService;
            this.navigationService = navigationService;

            Filter = "No filter";
            Role = "ROLE_USER";

            LoadCommands();
        }

        #region Commands section
        public CustomCommand DeleteUserCommand { get; set; }
        public CustomCommand AddUserCommand { get; set; }

        private void LoadCommands()
        {
            DeleteUserCommand = new CustomCommand(DeleteUser, CanExecute);
            AddUserCommand = new CustomCommand(AddUser, CanExecute);
        }

        private async void AddUser(object obj)
        {
            if (!String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Role))
            {
                User user = new User();
                user.Password = Password;
                user.Username = Username;
                user.Enabled = true;
                List<UserRole> userRoles = new List<UserRole>();

                if (Role.Equals("ROLE_ADMIN"))
                {         
                    userRoles.Add(new UserRole() { Role = "ROLE_ADMIN", Username = this.Username });
                    userRoles.Add(new UserRole() { Role = "ROLE_USER", Username = this.Username });
                }
                else
                {
                    userRoles.Add(new UserRole() { Role = "ROLE_USER", Username = this.Username });
                }

                user.Role = userRoles;

                if(!(await userService.addUser(user)))
                {
                    Error = "Error bij het toevoegen van de user. Probeer het later opnieuw!";
                }
            }
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private async void DeleteUser(object obj)
        {
            if (!String.IsNullOrEmpty(DeleteUsername) || DeleteUserObj != null)
            {
                User user = DeleteUserObj;
                if (DeleteUserObj == null)
                {
                    user = await userService.getUserByUsername(DeleteUsername);
                }
                
                if (!(await userService.deleteUser(user)))
                {
                    Error = "Error bij het verwijderen van de user. Probeer het later opnieuw!";
                }
            }
        }
        #endregion       
    } 
}
