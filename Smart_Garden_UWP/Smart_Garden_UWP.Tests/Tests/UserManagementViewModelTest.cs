using Smart_Garden_UWP.Extensions;
using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Tests.Mocks;
using Smart_Garden_UWP.ViewModels;
using Smart_Garden_UWP_Models;
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
        public void TestAllUsersLoaded()
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
    }
}
