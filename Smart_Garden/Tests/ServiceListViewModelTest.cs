using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Garden.ViewModels;
using Smart_Garden.Models;
using Moq;
using Smart_Garden.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ServiceListViewModelTest
    {

        private ServiceListViewModel vm;
        private User user;

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
            user.Sensors = new List<Sensor>();

            var mockUserService = new Mock<UserService>();
            mockUserService.Setup(u => u.addSensorToUser(It.IsAny<User>())).Returns(TaskBool);

            vm = new ServiceListViewModel(user, mockUserService.Object);
        }
            

        [TestMethod]
        public void TestAddEntity()
        {
            Assert.IsTrue(vm.AddEntity().Result);
        }
    }
}
