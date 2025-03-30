using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddFavourites(int userId, int bookId)
        {
            var favourite = await _repo.AddFavouritesAsync(userId, bookId);

            if (favourite == null)
                return BadRequest("Unable to add favourite.");

            return Ok(favourite);
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
