using Entities.Entites;
using Repository.Interfaces;
using Service.DTOs;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product?>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<Product?> CreateProduct(ProductDTO product)
        {
            var productInsert = new Product
            {
                Description = product.Description,
                PurchasePrice = product.PurchasePrice,
                SaleValue = product.SaleValue,
                StockBalance = product.StockBalance
            };

            return await _productRepository.CreateProduct(productInsert);
        }

        public async Task<bool> UpdateProduct(ProductDTO product)
        {
            var productEntity = await _productRepository.GetProductById(product.IdProduct ?? 0);
            if (productEntity == null)
            {
                return false;
            }

            productEntity.Description = product.Description;
            productEntity.PurchasePrice = product.PurchasePrice;
            productEntity.SaleValue = product.SaleValue;
            productEntity.StockBalance = product.StockBalance;

            return await _productRepository.UpdateProduct(productEntity);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
