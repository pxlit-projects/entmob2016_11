using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Garden.ViewModels;
using Smart_Garden.Services;
using Moq;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using Smart_Garden.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Smart_Garden.Pages;

namespace Tests
{
    [TestClass]
    public class LoginViewModelTest
    {
        private LoginViewModel vm;
        private Mock<INavigation> mockNavigation = new Mock<INavigation>();

        private Task<User> TaskUser()
        {
            return Task.Run(() =>
            {

                UserRole uRole = new UserRole();
                uRole.Username = "test";
                uRole.Role = "ROLE_ADMIN";
                uRole.User_role_id = 1;

                User user = new User();
                user.Id = 1;
                user.Password = "pass";
                user.Username = "test";
                user.Role = new List<UserRole> { uRole };
                user.Enabled = true;
                return user;
            });
        }

        [TestInitialize]
        public void Initialize()
        {
            var mockAdapter = new Mock<IAdapter>();
            var mockBlueTooth = new Mock<IBluetoothLE>();
            
            var mockUserService = new Mock<UserService>();

            mockUserService.Setup(u => u.getUserByUsername(It.IsAny<string>())).Returns(TaskUser);

            vm = new LoginViewModel(mockAdapter.Object, mockBlueTooth.Object, mockNavigation.Object);
            vm.UserService = mockUserService.Object;
            
        }

        [TestMethod]
        public void TestLoginWrongUser()
        {
            vm.Password = "notpass";
            vm.Username = "test";
            vm.Login(new Object());

            mockNavigation.Verify(n => n.PushAsync(It.IsAny<DeviceList>()), Times.Never());


        }
    }
}
