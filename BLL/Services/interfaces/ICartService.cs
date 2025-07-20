using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task AddOrUpdateCartItemAsync(int cartId, int productId, int quantity); // Thêm hoặc cập nhật sản phẩm
        Task RemoveCartItemAsync(int cartItemId); // Xóa sản phẩm trong giỏ hàng
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task UpdateCartItemAsync(CartItem cartItem); // Cập nhật số lượng sản phẩm trong giỏ hàng
    }

}
