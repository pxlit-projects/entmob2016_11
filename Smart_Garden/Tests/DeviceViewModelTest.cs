using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Garden.ViewModels;
using Moq;
using Xamarin.Forms;
using Plugin.BLE.Abstractions.Contracts;
using Smart_Garden.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class DeviceViewModelTest
    {
        private DeviceViewModel vm;

        private User user;

        Mock<INavigation> mockNavigation;
        Mock<IAdapter> mockAdapter;
        Mock<IBluetoothLE> mockBlueTooth;

        private Task<bool> TaskBool()
        {
            return Task.Run(() =>
            {


                return true;
            });
        }

        [TestInitialize]
        public void Initialize()
        {
            UserRole uRole = new UserRole();
            uRole.Username = "test";
            uRole.Role = "ROLE_ADMIN";
            uRole.User_role_id = 1;

            user = new User();
            user.Id = 1;
            user.Password = "pass";
            user.Username = "test";
            user.Role = new List<UserRole> { uRole };
            user.Enabled = true;

            mockNavigation = new Mock<INavigation>();
            mockAdapter = new Mock<IAdapter>();
            mockBlueTooth = new Mock<IBluetoothLE>();

            vm = new DeviceViewModel(user, mockAdapter.Object, mockBlueTooth.Object, mockNavigation.Object);

        }

        [TestMethod]
        public void TestConnectDeviceAsync()
        {

            Assert.IsTrue(vm.ConnectDeviceAsync(new Mock<DeviceItemViewModel>(new Mock<IDevice>().Object).Object).Result);
        }
    }
}
