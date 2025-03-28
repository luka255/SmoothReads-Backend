using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using System.Data.Entity;

namespace SmoothReads_Backend.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDBContext _context;
        public FavouriteRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Favourite?> AddFavouritesAsync(int userId, int bookId)
        {
            var favourtieModel = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);
    
            if (favourtieModel != null) 
                return null;

            var newFavourite = new Favourite
            {
                UserId = userId,
                BookId = bookId,
            };

            await _context.Favourites.AddAsync(newFavourite);
            await _context.SaveChangesAsync();  
            return newFavourite;
        }

        public async Task<List<Favourite>?> GetFavouritesByUserIdAsync(int userId)
        {
            return await _context.Favourites.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<Favourite?> RemoveFavouritesAsync(int userId, int bookId)
        {
            var favourtieModel = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);

            if (favourtieModel == null)
                return null;

            _context.Favourites.Remove(favourtieModel);
            await _context.SaveChangesAsync();
            return favourtieModel;
        }
    }
}
