using Smart_Garden_UWP.Extensions;
using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Tests.Mocks;
using Smart_Garden_UWP.ViewModels;
using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Smart_Garden_UWP.Tests.Tests
{
    public class UserManagementViewModelTest
    {

        IUserService userService;

        public UserManagementViewModelTest()
        {
            userService = new MockUserService(new MockUserRepository());
        }

        [Fact]
        public void TestAllUsersLoadedWithFilterUnchanged()
        {
            //Arrange
            ObservableCollection<User> users = null;
            ObservableCollection<User> expectedUsers = ListExtensions.ToObservableCollection(userService.getAllUsers().Result);

            //Act
            var userManagementViewModel = new UserManagementViewModel(this.userService, new NavigationService());
            while (users == null)
            {
                users = userManagementViewModel.UsersList;
            }


            //Assert
            Assert.Equal(users, expectedUsers);
        }

        [Fact]
        public void TestAllUsersLoadedWithFilterChanged()
        {
            //Arrange
            ObservableCollection<User> users = null;
            ObservableCollection<User> expectedUsers = ListExtensions.ToObservableCollection(userService.getAllUsers().Result);

            //Act
            var userManagementViewModel = new UserManagementViewModel(this.userService, new NavigationService());
            userManagementViewModel.Filter = "No filter";
            while (users == null)
            {
                users = userManagementViewModel.UsersList;
            }


            //Assert
            Assert.Equal(users, expectedUsers);
        }

        [Fact]
        public void TestPropertiesAreNullAtInitialize()
        {
            //Arrange
            var userManagementViewModel = new UserManagementViewModel(this.userService, new NavigationService());
            List<String> list = new List<String>();
            list.Add(userManagementViewModel.DeleteUsername);
            list.Add(userManagementViewModel.Password);
            list.Add(userManagementViewModel.Role);
            list.Add(userManagementViewModel.Username);

            //Assert
            Assert.All(list, x => String.IsNullOrEmpty(x));
        }

        [Fact]
        public void TestComboBoxRolesAreCorrect()
        {
            //Arrange
            List<String> actualRoles = null;
            List <String> expectedRoles = new List<String> { "ROLE_ADMIN", "ROLE_USER" };

            //Act
            var userManagementViewmodel = new UserManagementViewModel(this.userService, new NavigationService());
            actualRoles = userManagementViewmodel.Roles;

            //Assert
            Assert.Equal(expectedRoles, actualRoles);

        }

        [Fact]
        public void TestComboBoxFiltersAreCorrect()
        {
            //Arrange
            List<String> actualFilters = null;
            List<String> expectedFilters = new List<String> { "No filter", "Admins", "Users" };

            //Act
            var userManagementViewmodel = new UserManagementViewModel(this.userService, new NavigationService());
            actualFilters = userManagementViewmodel.UserFilters;

            //Assert
            Assert.Equal(expectedFilters, actualFilters);

        }

        [Fact]
        public void TestCommand1NotNull()
        {
            var userManagementViewModel = new UserManagementViewModel(this.userService, new NavigationService());

            Assert.NotNull(userManagementViewModel.AddUserCommand);
        }

        [Fact]
        public void TestCommand2NotNull()
        {
            var userManagementViewModel = new UserManagementViewModel(this.userService, new NavigationService());

            Assert.NotNull(userManagementViewModel.DeleteUserCommand);
        }


    }
}
