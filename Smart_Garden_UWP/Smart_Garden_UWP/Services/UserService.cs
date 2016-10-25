using System.Threading.Tasks;
using Smart_Garden_UWP_Repo.Repository;
using Smart_Garden_UWP_Models;
using System.Collections.Generic;

namespace Smart_Garden_UWP.Services
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository();

        public async Task<List<User>> getAllUsers()
        {
            return await userRepository.getAllUsers();
        }

        public async Task<User> getUserByUsername(string username)
        {
            return await userRepository.getUserByUsername(username);
        }
    }
}