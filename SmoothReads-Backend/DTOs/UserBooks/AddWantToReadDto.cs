namespace SmoothReads_Backend.DTOs.UserBooks
{
    using SmoothReads_Backend.Models;
    public class AddWantToReadDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string? UserName { get; set; }
        public string? BookTitle { get; set; }
    }
}
