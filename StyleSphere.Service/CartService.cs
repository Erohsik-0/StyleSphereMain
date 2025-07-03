using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StyleSphere.DataAccess.DbContext;
using StyleSphere.Domain.Entities;
using StyleSphere.Domain.Interfaces.ICart;


namespace StyleSphere.Service
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;
       
  

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
       
        }

        public async Task<List<CartItem>> GetCartAsync(string userId)
        {
            return await _cartRepository.GetCartItemsByUserAsync(userId);
        }

        public async Task AddToCartAsync(string userId , int productId , int quantity=1)
        {
            var products = await _cartRepository.GetCartItemsByUserAsync(userId);
            if(products == null)
            {
                throw new Exception("Product not found");
            }

            var existingItem = products.FirstOrDefault( c => c.ProductId == productId && c.UserId == userId);

            if(existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _cartRepository.UpdateQunatityAsync(existingItem.Id , existingItem.Quantity);
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = quantity
                };

                await _cartRepository.AddToCartAsync(cartItem);
            }
        }

        
        public async Task RemoveAsync(int cartItemId)
        {
            await _cartRepository.RemoveFromCartAsync(cartItemId);
        }

        

    }
}
