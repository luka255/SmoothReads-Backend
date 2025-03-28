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

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Read> Reads { get; set; }
        public DbSet<WantToRead> WantToReads { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
    }
}
