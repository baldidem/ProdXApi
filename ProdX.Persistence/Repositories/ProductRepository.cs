using Microsoft.EntityFrameworkCore;
using ProdX.Application.Interfaces;
using ProdX.Domain.Entities;
using ProdX.Persistence.DbContexts;

namespace ProdX.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProdXDbContext _context;

        public ProductRepository(ProdXDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA: " + ex.Message);
                throw;
            }
       
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
