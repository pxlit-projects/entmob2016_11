using Smart_Garden_UWP_Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using SmarT_Garden_UWP_Models.Models;

namespace Smart_Garden_UWP.Tests.Mocks
{
    class MockUserRepository : IUserRepository
    {

        private List<User> users;

        public MockUserRepository()
        {
            loadData();
        }

        private void loadData()
        {
            users = new List<User> { new User { Username = "Brian", Id = 1, Enabled = true, Password = "123", Role = null, Sensors = null },
                                     new User { Username = "Robin", Id = 2, Enabled = true, Password = "456", Role = null, Sensors = null },
                                     new User { Username = "Charel", Id = 3, Enabled = true, Password = "789", Role = null, Sensors = null } };
        }

        public Task<bool> addUser(User user)
        {
            users.Add(user);
            Task<Boolean> task = Task.Factory.StartNew(() => true);
            return task;
        }

        public Task<bool> deleteUser(User user)
        {
            users.Remove(user);
            Task<Boolean> task = Task.Factory.StartNew(() => true);
            return task;
        }

        public Task<List<User>> getAllUsers()
        {
            Task<List<User>> task = Task.Factory.StartNew(() => users);
            return task;
        }

        public Task<User> getUserByUsername(string username)
        {
            User user = users.Find(u => u.Username.Equals(username));
            Task<User> task = Task.Factory.StartNew(() => user);
            return task;
        }
    }
}
