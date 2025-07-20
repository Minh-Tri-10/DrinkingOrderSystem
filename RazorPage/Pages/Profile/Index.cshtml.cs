using BLL.Services.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userService;

        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Giả lập lấy userId, thực tế bạn sẽ lấy từ session hoặc claims
            int userId = 1;

            CurrentUser = await _userService.GetByIdAsync(userId);

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

            try
            {
                // Cập nhật người dùng trong cơ sở dữ liệu
                await _userService.UpdateAsync(CurrentUser);
                ViewData["Message"] = "Cập nhật thành công!";
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có vấn đề khi cập nhật
                ViewData["Message"] = "Cập nhật thất bại: " + ex.Message;
            }

            return Page();
        }
    }
}
