using BLL.Services.interfaces;
using DAL.Models;
using DAL.Repositories.interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;

        public CartService(ICartRepository repo)
        {
            _repo = repo;
        }

        public Task<Cart> GetCartByUserIdAsync(int userId) =>
            _repo.GetCartByUserIdAsync(userId);

        public Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId) =>
            _repo.GetCartItemsAsync(cartId);

        public async Task AddOrUpdateCartItemAsync(int cartId, int productId, int quantity)
        {
            var items = await _repo.GetCartItemsAsync(cartId);
            var existing = items.FirstOrDefault(x => x.ProductId == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
                await _repo.UpdateCartItemAsync(existing);
            }
            else
            {
                await _repo.AddCartItemAsync(new CartItem { CartId = cartId, ProductId = productId, Quantity = quantity });
            }
        }

        public Task RemoveCartItemAsync(int cartItemId) =>
            _repo.RemoveCartItemAsync(cartItemId);

        // Thêm phương thức GetCartItemByIdAsync để lấy cartItem theo id
        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId) =>
            await _repo.GetCartItemByIdAsync(cartItemId);

        // Phương thức cập nhật cartItem
        public async Task UpdateCartItemAsync(CartItem cartItem) =>
            await _repo.UpdateCartItemAsync(cartItem);
    }
}
