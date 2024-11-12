using Microsoft.EntityFrameworkCore;
using TP03.Models;

namespace TP03.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
