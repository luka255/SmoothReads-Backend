namespace SmoothReads_Backend.DTOs.Favourite
{
    using SmoothReads_Backend.Models;
    public class AddFavouriteDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
