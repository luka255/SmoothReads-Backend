using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmoothReads_Backend.DTOs.Favourite;

namespace SmoothReads_Backend.Interfaces
{
    public interface IFavouriteRepository
    {
        Task<List<FavouriteDto>?> GetFavouritesByUserIdAsync(int userId);
        Task<Favourite?> AddFavouritesAsync(AddFavouriteDto favouriteDto);
        Task<Favourite?> RemoveFavouritesAsync(int userId, int bookId);
    }
}