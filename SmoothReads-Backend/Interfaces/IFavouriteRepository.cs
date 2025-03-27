using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFavouriteRepository
{
    Task<IEnumerable<Favourite>> GetFavouritesByUserIdAsync(int userId);
    Task<Favourite> AddFavouritesAsync(int userId, int bookId);
    Task<Favourite> RemoveFavourites(int userId, int bookId);
}
