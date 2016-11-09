using Smart_Garden_UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP_Repo.Repository;

namespace Smart_Garden_UWP.Tests.Mocks
{
    class MockUserService : IUserService
    {
        private IUserRepository userRepository;

        public MockUserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public Task<bool> addUser(User user)
        {
            return userRepository.addUser(user);
        }

        public Task<bool> deleteUser(User user)
        {
            return userRepository.deleteUser(user);
        }

        public Task<List<User>> getAllUsers()
        {
            return userRepository.getAllUsers();
        }

        public Task<User> getUserByUsername(string username)
        {
            return userRepository.getUserByUsername(username);
        }
    }
}
