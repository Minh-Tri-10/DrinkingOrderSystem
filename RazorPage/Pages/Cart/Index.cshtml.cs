using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;

        public IndexModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal Total { get; set; }

        public async Task OnGetAsync()
        {
            int userId = 1; // Lấy từ login thật
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart != null)
            {
                CartItems = await _cartService.GetCartItemsAsync(cart.CartId);
                // Tính tổng giá trị giỏ hàng
                Total = CartItems.Sum(i => (i.Product?.Price ?? 0) * i.Quantity);
            }
            else
            {
                CartItems = new List<CartItem>();
                Total = 0;
            }
        }

        public async Task<IActionResult> OnPostRemoveAsync(int cartItemId)
        {
            await _cartService.RemoveCartItemAsync(cartItemId);
            return RedirectToPage();
        }

        // Phương thức cập nhật số lượng sản phẩm trong giỏ hàng
        public async Task<IActionResult> OnPostUpdateQuantityAsync(int cartItemId, int quantity)
        {
            if (quantity <= 0)
            {
                return RedirectToPage(); // Nếu số lượng không hợp lệ, trả về trang giỏ hàng.
            }

            var cartItem = await _cartService.GetCartItemByIdAsync(cartItemId); // Lấy cartItem
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await _cartService.UpdateCartItemAsync(cartItem); // Cập nhật số lượng
            }

            return RedirectToPage(); // Quay lại trang giỏ hàng sau khi cập nhật
        }

        // Phương thức thanh toán
        public async Task<IActionResult> OnPostPaymentAsync()
        {
            // Thực hiện thanh toán qua VnPay hoặc phương thức tương tự
            // Ví dụ: await _paymentService.ProcessPaymentAsync();

            return RedirectToPage("Success"); // Chuyển đến trang thành công
        }
    }
}
