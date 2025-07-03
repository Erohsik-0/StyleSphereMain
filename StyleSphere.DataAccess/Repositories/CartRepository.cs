using StyleSphere.Domain.Entities;
using StyleSphere.Domain.Interfaces.ICart;
using StyleSphere.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace StyleSphere.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {

        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetCartItemsByUserAsync(string userId)
        {
            return await _context.CartItems.Include(c => c.Product).Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateQunatityAsync(int cartId , int newQuantity)
        {
            var item = await _context.CartItems.FindAsync(cartId);

            if(item != null)
            {
                item.Quantity = newQuantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if(item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            var items = _context.CartItems.Where(c => c.UserId == userId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

    }
}
