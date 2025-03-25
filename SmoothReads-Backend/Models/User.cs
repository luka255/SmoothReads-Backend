using System.Xml.Linq;

namespace SmoothReads_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Read> Reads { get; set; } = new List<Read>();
        public List<WantToRead> WantsToReads { get; set; } = new List<WantToRead>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
