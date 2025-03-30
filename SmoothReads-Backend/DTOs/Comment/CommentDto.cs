using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public float Rating { get; set; }
    }
}
