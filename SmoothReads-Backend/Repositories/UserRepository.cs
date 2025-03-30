using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace SmoothReads_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _Context;
        public UserRepository(ApplicationDBContext context)
        {
            _Context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _Context.AddAsync(user);
            await _Context.SaveChangesAsync();
            return user;
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
    }
}
