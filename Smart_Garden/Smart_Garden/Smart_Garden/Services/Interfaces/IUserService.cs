using Smart_Garden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> getAllUsers();

        Task<User> getUserByUsername(string username);

        Task<bool> addSensorToUser(User user);
    }
}
