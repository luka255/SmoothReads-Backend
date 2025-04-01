using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.DTOs.Favourite;
using SmoothReads_Backend.Interfaces;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteRepository _repo;
        public FavouriteController(IFavouriteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavouriteByUserId(int userId)
        {
            var favourites = await _repo.GetFavouritesByUserIdAsync(userId);
            return Ok(favourites);
        }

        [HttpPost("{userId}/{bookId}")]
        public async Task<IActionResult> AddFavourites([FromRoute] int userId, [FromRoute] int bookId)
        {
            var favouriteDto = new AddFavouriteDto { UserId = userId, BookId = bookId };

            var favourite = await _repo.AddFavouritesAsync(favouriteDto);

            if (favourite == null)
                return BadRequest("Unable to add favourite.");

            return CreatedAtAction(nameof(AddFavourites), new {id = favourite.Id},favourite);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFavourites(int userId, int bookId)
        {
            var favourites = await _repo.GetFavouritesByUserIdAsync(userId);

            if (favourites == null)
                return BadRequest();

            await _repo.RemoveFavouritesAsync(userId, bookId);
            return Ok(favourites);
        }

    }
}
