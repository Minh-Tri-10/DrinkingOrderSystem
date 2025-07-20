using BLL.Services.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPage.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public IndexModel(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IEnumerable<Product> Products { get; set; }

        // Fetch all the products when the page is loaded
        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllAsync();
        }

        // Handle the Add to Cart button click
        public async Task<IActionResult> OnPostAddToCartAsync(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return RedirectToPage(); // Invalid quantity, redirect to the same page
            }

            var userId = 1; // Example: Get the logged-in user ID here (in a real app, get the actual logged-in user's ID)
            var product = await _productService.GetByIdAsync(productId);

            if (product != null)
            {
                var cart = await _cartService.GetCartByUserIdAsync(userId);
                if (cart != null)
                {
                    // Add or update the cart item
                    await _cartService.AddOrUpdateCartItemAsync(cart.CartId, productId, quantity);
                }
            }

            return RedirectToPage(); // Redirect back to the product list page
        }
    }
}
