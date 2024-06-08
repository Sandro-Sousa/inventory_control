using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product?>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.IdProduct == id);
        }

        public async Task<Product?> CreateProduct(Product product)
        {
            if (product is null)
            {
                return null;
            }
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (product is null)
            {
                return false;
            }
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.IdProduct == id);
            if (product is null)
            {
                return false;
            }
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
