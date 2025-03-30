namespace SmoothReads_Backend.DTOs.Book
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
