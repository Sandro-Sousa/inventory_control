
using Entities.Entites;
using Service.DTOs;

namespace Repository.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product?>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateProduct(ProductDTO product);
        Task<bool> UpdateProduct(ProductDTO product);
        Task<bool> DeleteProduct(int id);
    }
}
