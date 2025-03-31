using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace SmoothReads_Backend.Interfaces.Repositories
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
            var favouriteModel  = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);
    
            if (favouriteModel != null) 
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
            return await _context.Favourites
                .Where(f => f.UserId == userId)
                .Include(f => f.Book)
                .ToListAsync();
        }

        public async Task<Favourite?> RemoveFavouritesAsync(int userId, int bookId)
        {
            var favouriteModel = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);

            if (favouriteModel == null)
                return null;

            _context.Favourites.Remove(favouriteModel);
            await _context.SaveChangesAsync();
            return favouriteModel;
        }
    }
}
