using StyleSphere.Domain.Interfaces.IProduct;
using StyleSphere.Domain.Entities;

namespace StyleSphere.Service
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()

        {
            try
            {
                return await _productRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

    }
}
