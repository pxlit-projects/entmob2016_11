using System.Threading.Tasks;
using Smart_Garden_UWP_Repo.Repository;
using Smart_Garden_UWP_Models;
using System.Collections.Generic;
using System;
using Smart_Garden_UWP.Services.Interfaces;

namespace Smart_Garden_UWP.Services
{
    public class UserService : IUserService
    {

        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> getAllUsers()
        {
            return await userRepository.getAllUsers();
        }

        public async Task<User> getUserByUsername(string username)
        {
            return await userRepository.getUserByUsername(username);
        }

        public async Task<Boolean> addUser(User user)
        {
            return await userRepository.addUser(user);
        }

        public async Task<Boolean> deleteUser(User user)
        {
            return await userRepository.deleteUser(user);
        }
    }
}