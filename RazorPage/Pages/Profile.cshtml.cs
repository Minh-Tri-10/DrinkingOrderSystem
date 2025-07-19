using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly DrinkOrderDbContext _context;

        public ProfileModel(DrinkOrderDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // L?y ID user hi?n t?i (gi? s? ?ã ??ng nh?p, l?y t? session/claims)
            int userId = 1; // Thay b?ng l?y t? ??ng nh?p th?c t?
            CurrentUser = await _context.Users.FindAsync(userId);

            if (CurrentUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Update user
            _context.Users.Update(CurrentUser);
            await _context.SaveChangesAsync();

            ViewData["Message"] = "C?p nh?t thành công!";
            return Page();
        }
    }
}
