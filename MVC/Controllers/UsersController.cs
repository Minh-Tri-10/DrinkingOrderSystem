using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using BLL.Services.interfaces;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }





        // GET: Users/Create
        public IActionResult Create() => View();

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId) return NotFound();
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        // GET: Users
        public async Task<IActionResult> Index(string? keyword, string? role, bool? isBanned)
        {
            // Nếu không truyền gì sẽ lấy tất cả
            var users = await _userService.SearchAsync(keyword, null, isBanned);
            return View(users);
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }
        // POST: Users/Ban/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Nếu dùng phân quyền Identity thì thêm [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ban(int id)
        {
            await _userService.BanAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Users/Unban/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Unban(int id)
        {
            await _userService.UnbanAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private bool IsAdmin()
        {
            // Nếu bạn lưu role vào session hoặc claim:
            // return User.IsInRole("Admin");
            // Hoặc tự check session/cookie: HttpContext.Session.GetString("Role") == "Admin"
            return true; // Giả sử luôn là admin để code demo
        }

    }
}