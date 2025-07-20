using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);  // Thêm phương thức này
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task RemoveCartItemAsync(int cartItemId);
    }
}
