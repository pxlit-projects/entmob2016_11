using Smart_Garden.Models;
using Smart_Garden.Repository;
using Smart_Garden.Repository.Interfaces;
using Smart_Garden.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }


        public async Task<List<User>> getAllUsers()
        {
            return await userRepository.getAllUsers();
        }

        public async Task<User> getUserByUsername(string username)
        {
            return await userRepository.getUserByUsername(username);
        }
        public async Task<bool> addSensorToUser(User user)
        {
            return await userRepository.updateUser(user);
        }
    }
}
