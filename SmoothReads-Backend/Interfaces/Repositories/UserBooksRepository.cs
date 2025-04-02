using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;
using SmoothReads_Backend.DTOs.UserBooks;
using SmoothReads_Backend.Mappers;


namespace SmoothReads_Backend.Interfaces.Repositories
{
    public class UserBooksRepository : IUserBooksRepository
    {
        private readonly ApplicationDBContext _context;
        public UserBooksRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Read> AddReadBooksAsync(AddReadDto read)
        {
            var readBook = read.CreateReadDto();

            await _context.Reads.AddAsync(readBook);
            await _context.SaveChangesAsync();
            return readBook;
        }

        public async Task<WantToRead> AddWantToReadBooksAsync(AddWantToReadDto wantToRead)
        {
            var wtrBook =  wantToRead.CreateWantToReadDto();

            await _context.WantToReads.AddAsync(wtrBook);
            await _context.SaveChangesAsync();
            return wtrBook;
        }

        public async Task<Read?> DeleteReadBookAsync(int userId, int bookId)
        {
            var readBookModel = await _context.Reads.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
            
            if (readBookModel == null)
                return null;

            _context.Reads.Remove(readBookModel);
            await _context.SaveChangesAsync();
            return readBookModel;

        }

        public async Task<WantToRead?> DeleteWantToReadBookAsync(int userId, int bookId)
        {
            var wantToReadModel = await _context.WantToReads.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);

            if (wantToReadModel == null)
                return null ;

            _context.WantToReads.Remove(wantToReadModel);
            await _context.SaveChangesAsync();
            return wantToReadModel;
        }

        public async Task<List<Read>> GetReadBooksAsync(int userId)
        {
            return await _context.Reads.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<List<WantToRead>> GetWantToReadBooksAsync(int userId)
        {
            return await _context.WantToReads.Where(u => u.UserId == userId).ToListAsync();
        }
    }
}
