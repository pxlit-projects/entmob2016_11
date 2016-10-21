using System.Threading.Tasks;
using Smart_Garden_UWP_Repo.Repository;

namespace Smart_Garden_UWP.Services
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository();

        public async Task<string> getAllUsers()
        {
            return await userRepository.getAllUsers();
        }
    }
}