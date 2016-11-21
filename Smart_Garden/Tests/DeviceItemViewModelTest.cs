using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Garden.ViewModels;
using Moq;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace Tests
{
    [TestClass]
    public class DeviceItemViewModelTest
    {

        private DeviceItemViewModel vm;

        [TestInitialize]
        public void Initialize()
        {
            var mockDevice = new Mock<IDevice>();
            mockDevice.Setup(d => d.State).Returns(() => DeviceState.Connected);
            vm = new DeviceItemViewModel(mockDevice.Object);
        }

        [TestMethod]
        public void TestisConnected()
        {
            Assert.IsTrue(vm.IsConnected);
        }
    }
}
