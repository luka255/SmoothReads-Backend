using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;
using SmoothReads_Backend.DTOs.Book;
using SmoothReads_Backend.Mappers;
using SmoothReads_Backend.DTOs.Favourite;
using SmoothReads_Backend.DTOs.Comment;
using SmoothReads_Backend.DTOs.User;


namespace SmoothReads_Backend.Interfaces.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDBContext _context;
        public FavouriteRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Favourite?> AddFavouritesAsync(AddFavouriteDto favouriteDto)
        {
            var favouriteModel = favouriteDto.ToFavouriteFromCreateDto();

            await _context.Favourites.AddAsync(favouriteModel);
            await _context.SaveChangesAsync();  
            return favouriteModel;
        }

        public async Task<List<FavouriteDto>?> GetFavouritesByUserIdAsync(int userId)
        {
            var favouriteModel = await _context.Favourites
                .Include(b => b.Book)
                .Include(u => u.User)
                .Where(f => f.UserId == userId)
                .ToListAsync();

            if (!favouriteModel.Any())
                return new List<FavouriteDto>();

            return favouriteModel.Select(f => new FavouriteDto
            {
                Id = f.Id,
                UserId = f.UserId,
                BookId = f.UserId,
                User = new List<UserDto>
                {
                  new UserDto { Name = f.User.Name }
                },
                Book = new List<BookDto>
                {
                  new BookDto 
                  { 
                      Id = f.Book.Id,
                      Title = f.Book.Title,
                      Author = f.Book.Author,
                      Genre = f.Book.Genre,
                      Description = f.Book.Description,
                      PublicationYear = f.Book.PublicationYear,
                      Rating = f.Book.Rating,
                      ImageUrl = f.Book.ImageUrl
                  }
                }
            }).ToList();
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
