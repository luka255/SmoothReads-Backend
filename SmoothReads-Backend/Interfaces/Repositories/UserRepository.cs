using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;
using SmoothReads_Backend.DTOs.User;
using SmoothReads_Backend.Mappers;

namespace SmoothReads_Backend.Interfaces.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _Context;
        public UserRepository(ApplicationDBContext context)
        {
            _Context = context;
        }

        public async Task<User> AddUserAsync(CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();

            //userModel.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            await _Context.AddAsync(userModel);
            await _Context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _Context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _Context.Users.FirstOrDefaultAsync(u => u.Email == email);

        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _Context.Users
                .Include(u => u.Reads)
                .Include(u => u.WantsToReads)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UserExist(int userId)
        {
            return await _Context.Users.AnyAsync(u => u.Id==userId);
        }
    }
}
