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

        public DbSet<Cliente> Cliente {get; set;}

        public DbSet<Pagamento> Pagamento {get; set;}

        public DbSet<Transportadora> Transportadora {get; set;}

        public DbSet<Vendedor> Vendedor {get; set;}
    }
}