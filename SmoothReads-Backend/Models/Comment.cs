namespace SmoothReads_Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public string text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public float Rating { get; set; }
    }
}
