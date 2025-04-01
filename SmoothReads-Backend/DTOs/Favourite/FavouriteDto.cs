namespace SmoothReads_Backend.DTOs.Favourite
{
    using SmoothReads_Backend.DTOs.Book;
    using SmoothReads_Backend.DTOs.User;
    using SmoothReads_Backend.Models;
    public class FavouriteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public List<UserDto>? User { get; set; }
        public List<BookDto>? Book { get; set; }
    }
}
