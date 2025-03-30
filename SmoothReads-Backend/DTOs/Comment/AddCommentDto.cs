using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.DTOs.Comment
{
    public class AddCommentDto
    {
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public float Rating { get; set; }
    }
}
