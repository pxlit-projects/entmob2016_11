using Smart_Garden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> getAllUsers();
        Task<User> getUserByUsername(String username);
    }
}
