
using Entities.Entites;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
