using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmoothReads_Backend.Interfaces
{
    public interface IFavouriteRepository
    {
        Task<List<Favourite>?> GetFavouritesByUserIdAsync(int userId);
        Task<Favourite?> AddFavouritesAsync(int userId, int bookId);
        Task<Favourite?> RemoveFavouritesAsync(int userId, int bookId);
    }
}