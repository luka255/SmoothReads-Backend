using System.Xml.Linq;

namespace SmoothReads_Backend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Read> Reads { get; set; } = new List<Read>();
        public List<WantToRead> WantsToReads { get; set; } = new List<WantToRead>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
