using Microsoft.EntityFrameworkCore;

namespace micherlane.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Marca> Marca {get; set;}

        public DbSet<Produto> Produto {get; set;}
    }
}