using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Tests.Mocks;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP.ViewModels;
using Smart_Garden_UWP_Models;
using System.Collections.Generic;
using Xunit;

namespace Smart_Garden_UWP.Tests.Tests
{
    public class AdminViewModelTest
    {
        private IUserService userService;

        public AdminViewModelTest()
        {
            userService = new MockUserService(new MockUserRepository());
        }

        [Fact]
        public void TestUserThatMessengerReceives()
        {
            //Arrange
            User actualUser = null;
            User expectedUser = userService.getUserByUsername("Brian").Result;

            //Act
            var adminViewModel = new AdminViewModel(this.userService, new NavigationService(), new CropService());
            Messenger.Default.Send<User>(expectedUser);
            actualUser = adminViewModel.User;

            //Assert 
            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public void TestUserThatMessengerReceivesFaulty()
        {
            //Arrange
            User actualUser = null;
            User sentUser = userService.getUserByUsername("Robin").Result;
            User expectedUser = userService.getUserByUsername("Brian").Result;

            //Act
            var adminViewModel = new AdminViewModel(this.userService, new NavigationService(), new CropService());
            Messenger.Default.Send<User>(sentUser);
            actualUser = adminViewModel.User;

            //Assert 
            Assert.NotEqual(expectedUser, actualUser);
        }

        [Fact]
        public void TestWhenMessengerReceivesNothing()
        {
            var adminViewModel = new AdminViewModel(this.userService, new NavigationService(), new CropService());
            var user = adminViewModel.User;

            //Assert
            Assert.Null(user);
        }

        [Fact]
        public void TestThatCommand1GetsSet()
        {
            var adminViewModel = new AdminViewModel(this.userService, new NavigationService(), new CropService());

            Assert.NotNull(adminViewModel.ShowUserManagementCommand);
        }

        [Fact]
        public void TestThatCommand2GetsSet()
        {
            var adminViewModel = new AdminViewModel(this.userService, new NavigationService(), new CropService());

            Assert.NotNull(adminViewModel.ShowCropManagementCommand);
        }
    }
}
