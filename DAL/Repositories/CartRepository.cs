using DAL.Data;
using DAL.Models;
using DAL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DrinkOrderDbContext _context;

        public CartRepository(DrinkOrderDbContext context)
        {
            _context = context;
        }

        // Lấy giỏ hàng theo userId
        public async Task<Cart> GetCartByUserIdAsync(int userId) =>
            await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

        // Lấy tất cả CartItem trong giỏ hàng
        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId) =>
            await _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .Include(ci => ci.Product)
                .ToListAsync();

        // Thêm một CartItem vào giỏ
        public async Task AddCartItemAsync(CartItem item)
        {
            await _context.CartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        // Cập nhật CartItem
        public async Task UpdateCartItemAsync(CartItem item)
        {
            _context.CartItems.Update(item);
            await _context.SaveChangesAsync();
        }

        // Xóa CartItem trong giỏ
        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        // Lấy CartItem theo id
        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId) =>
            await _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId);
    }
}
