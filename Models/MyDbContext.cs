using Microsoft.EntityFrameworkCore;

namespace micherlane.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}