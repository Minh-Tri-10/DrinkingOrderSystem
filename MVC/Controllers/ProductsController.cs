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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService context)
        {
            _productService = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllWithCategoryAsync();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdWithCategoryAsync(id.Value);
            if (product == null) return NotFound();

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _productService.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,Price,Stock,CategoryId,CreatedAt")] Product product)
        {
            if (await _productService.ProductNameExistsAsync(product.ProductName))
            {
                ModelState.AddModelError("ProductName", "Tên sản phẩm đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _productService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(await _productService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,Price,Stock,CategoryId,CreatedAt")] Product product)
        {
            if (id != product.ProductId) return NotFound();

            if (await _productService.ProductNameExistsAsync(product.ProductName, product.ProductId))
            {
                ModelState.AddModelError("ProductName", "Tên sản phẩm đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productService.ExistsAsync(product.ProductId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _productService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetByIdWithCategoryAsync(id.Value);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
