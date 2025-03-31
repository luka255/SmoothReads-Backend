using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmoothReads_Backend.DTOs.User;

namespace SmoothReads_Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(CreateUserDto userDto);
        Task<bool> UserExist(int userId);
    }
}