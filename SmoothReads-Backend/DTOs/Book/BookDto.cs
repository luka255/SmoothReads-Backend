namespace SmoothReads_Backend.DTOs.Book
{
    using SmoothReads_Backend.DTOs.Comment;
    using SmoothReads_Backend.Models;
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<CommentDto> Comments { get; set; } = new();
        //public List<int> FavouriteUserIds { get; set; } = new();
    }
}
