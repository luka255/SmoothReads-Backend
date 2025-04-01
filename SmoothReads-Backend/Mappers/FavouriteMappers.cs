using SmoothReads_Backend.DTOs.Favourite;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Mappers
{
    public static class FavouriteMappers
    {
        public static FavouriteDto ToFavouriteDto (this Favourite favouriteModel)
        {
            return new FavouriteDto
            {
                Id = favouriteModel.Id,
                UserId = favouriteModel.UserId,
                BookId = favouriteModel.BookId,
            };
        }

        public static Favourite ToFavouriteFromCreateDto(this AddFavouriteDto favouriteModel)
        {
            return new Favourite
            {
                UserId = favouriteModel.UserId,
                BookId = favouriteModel.BookId
            };
        }
    }
}
