using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using System.Data.Entity;

namespace SmoothReads_Backend.Repositories
{
    public class UserBooksRepository : IUserBooksRepository
    {
        private readonly ApplicationDBContext _context;
        public UserBooksRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Read> AddReadBooksAsync(Read Read)
        {
            await _context.Reads.AddAsync(Read);
            await _context.SaveChangesAsync();
            return Read;
        }

        public async Task<WantToRead> AddWantToReadBooksAsync(WantToRead wantToRead)
        {
            await _context.WantToReads.AddAsync(wantToRead);
            await _context.SaveChangesAsync();
            return wantToRead;
        }

        public async Task<Read?> DeleteReadBookAsync(int userId, int bookId)
        {
            var readBookModel = await _context.Reads.FindAsync(userId, bookId);
            
            if (readBookModel == null)
                return null;

            _context.Reads.Remove(readBookModel);
            await _context.SaveChangesAsync();
            return readBookModel;

        }

        public async Task<WantToRead?> DeleteWantToReadBookAsync(int userId, int bookId)
        {
            var wantToReadModel = await _context.WantToReads.FindAsync(userId,bookId);

            if (wantToReadModel == null)
                return null ;

            _context.WantToReads.Remove(wantToReadModel);
            await _context.SaveChangesAsync();
            return wantToReadModel;
        }

        public async Task<List<Read>> GetReadBooksAsync(int userId)
        {
            return await _context.Reads.Where(u => u.Id == userId).ToListAsync();
        }

        public async Task<List<WantToRead>> GetWantToReadBooksAsync(int userId)
        {
            return await _context.WantToReads.Where(u => u.Id == userId).ToListAsync();
        }
    }
}
