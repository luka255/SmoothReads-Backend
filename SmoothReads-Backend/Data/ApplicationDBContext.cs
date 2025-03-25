using Microsoft.EntityFrameworkCore;
using SmoothReads_Backend.Models;
using System.Collections.Generic;

namespace SmoothReads_Backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Read> Reads { get; set; }
        public DbSet<WantToRead> WantToReads { get; set; }
        public DbSet<Favourite> favourites { get; set; }
    }
}
