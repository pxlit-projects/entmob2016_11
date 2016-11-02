using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Garden_UWP_Repo.Repository
{
    public interface IUserRepository
    {
        // Gets a user by his username
        Task<User> getUserByUsername(String username);
        // Gets a list of all users
        Task<List<User>> getAllUsers();

        // Adds a user to the database
        Task<Boolean> addUser(User user);
        // Delets a user from the database
        Task<Boolean> deleteUser(User user);
    }
}