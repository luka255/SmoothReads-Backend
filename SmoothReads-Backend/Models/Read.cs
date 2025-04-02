namespace SmoothReads_Backend.Models
{
    public class Read
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }

        //public string? UserName { get; set; }
        //public string? BookTitle { get; set; }

    }
}
