using Microsoft.EntityFrameworkCore;
using ProdX.Domain.Entities;

namespace ProdX.Persistence.DbContexts
{
    public class ProdXDbContext : DbContext
    {
        public ProdXDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
