using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Tests.Mocks;
using Smart_Garden_UWP.ViewModels;
using Smart_Garden_UWP_Models;
using System.Collections.Generic;
using Xunit;

namespace Smart_Garden_UWP.Tests
{
    public class LoginViewModelTest
    {

        private IUserService userService;

        public LoginViewModelTest()
        {
            userService = new MockUserService(new MockUserRepository());
        }


        #region user input tests
        [Fact]
        public void TestCorrectUserInput()
        {
            //Arrange
            User loadedUser = null;
            User expectedUser = userService.getUserByUsername("Brian").Result;

            //Act
            var viewModel = new LoginViewModel(this.userService, new NavigationService());
            viewModel.Username = "Brian";
            viewModel.Password = "123";
            loadedUser = viewModel.testForLogin().Result;
            

            //Assert
            Assert.Equal(expectedUser, loadedUser);

        }

        [Fact]
        public void TestIncorrectUserNameInput()
        {
            //Arrange
            User loadedUser = null;
            User expectedUser = userService.getUserByUsername("Brian").Result;

            //Act
            var viewModel = new LoginViewModel(this.userService, new NavigationService());
            viewModel.Username = "Robin";
            viewModel.Password = "456";
            loadedUser = viewModel.testForLogin().Result;

            //Assert
            Assert.NotEqual(expectedUser, loadedUser);
        }

        [Fact]
        public void TestNonExistingUserNameInput()
        {
            //Arrange
            User loadedUser = null;

            //Act
            var viewModel = new LoginViewModel(this.userService, new NavigationService());
            viewModel.Username = "NOTVALIDUSERNAME";
            viewModel.Password = "RANDOMPASSWORD";
            loadedUser = viewModel.testForLogin().Result;

            //Assert
            Assert.Null(loadedUser);
        }

        [Fact]
        public void TestCorrectUsernameButWrongPassword()
        {
            //Arrange
            User loadedUser = null;

            //Act
            var viewModel = new LoginViewModel(this.userService, new NavigationService());
            viewModel.Username = "Brian";
            viewModel.Password = "123456";
            loadedUser = viewModel.testForLogin().Result;

            //Assert
            Assert.Null(loadedUser);
        }
        #endregion

        #region other tests

        [Fact]
        public void testForCommandInitialized()
        {
            var viewModel = new LoginViewModel(this.userService, new NavigationService());

            //Assert
            Assert.NotNull(viewModel.LoginCommand);

        }

        [Fact]
        public void testInitializationOfProperties()
        {
            var viewModel = new LoginViewModel(this.userService, new NavigationService());

            //Assert
            Assert.All(new List<string> { viewModel.Username, viewModel.Password }, x => string.IsNullOrEmpty(x));
        }

        #endregion

    }
}
