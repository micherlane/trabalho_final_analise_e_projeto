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

        public DbSet<TipoDePagamento> TipoDePagamento {get; set;}

        public DbSet<PagamentoComCartao> PagamentoComCartao {get; set;}

        public DbSet<PagamentoComCheque> PagamentoComCheque {get; set;}

        public DbSet<NotaDaVenda> NotaDaVenda {get; set;}

        public DbSet<Item> Item { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDePagamento>()
                .HasMany(tipo => tipo.NotaDaVendas)
                .WithOne(nota => nota.TipoDePagamento)
                .HasForeignKey(nota => nota.TipoDePagamentoId);
        }
    }
}