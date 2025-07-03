using StyleSphere.Domain.Entities;

namespace StyleSphere.Domain.Interfaces.IProduct
{
    public interface IProductService
    {

        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);
        public Task AddProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(int id);

    }
}
