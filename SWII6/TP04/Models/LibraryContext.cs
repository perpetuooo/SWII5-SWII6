using Microsoft.EntityFrameworkCore;

namespace TP04.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}

// Pedro H Perpétuo CB3021688 & Igor Benites CB3021734