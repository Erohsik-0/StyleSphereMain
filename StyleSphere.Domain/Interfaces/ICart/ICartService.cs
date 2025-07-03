using StyleSphere.Domain.Entities;

namespace StyleSphere.Domain.Interfaces.ICart
{
    public interface ICartService
    {

        public Task<List<CartItem>> GetCartAsync(string userId);
        public Task AddToCartAsync(string userId , int productId , int quantity = 1);
        public Task RemoveAsync(int cartItemId);

    }
}
