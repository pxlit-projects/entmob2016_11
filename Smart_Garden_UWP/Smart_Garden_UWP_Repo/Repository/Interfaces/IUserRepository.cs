﻿using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP_Repo.Repository
{
    public interface IUserRepository
    {
        // Gets a user by his username
        User getUserByUsername();
        // Gets a list of all users
        Task<string> getAllUsers();

        // Adds a user to the database
        void addUser();
        // Delets a user from the database
        void deleteUser();
    }
}