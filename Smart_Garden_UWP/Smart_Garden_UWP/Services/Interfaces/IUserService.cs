using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> getAllUsers();

        Task<User> getUserByUsername(string username);

        Task<Boolean> addUser(User user);

        Task<Boolean> deleteUser(User user);     
    }
}
