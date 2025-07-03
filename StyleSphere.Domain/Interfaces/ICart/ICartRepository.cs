using StyleSphere.Domain.Entities;


namespace StyleSphere.Domain.Interfaces.ICart
{
    public  interface ICartRepository 
    {

        public Task<List<CartItem>> GetCartItemsByUserAsync(string userId);

        public Task AddToCartAsync(CartItem cartItem);

        public Task UpdateQunatityAsync(int cartId , int newQuantity);

        public Task RemoveFromCartAsync(int cartId);

        public Task ClearCartAsync(string userId);

    }
}
