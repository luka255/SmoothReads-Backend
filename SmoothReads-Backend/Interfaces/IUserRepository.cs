﻿using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmoothReads_Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}