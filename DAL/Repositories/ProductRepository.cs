using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.interfaces;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DrinkOrderDbContext _context;

        public ProductRepository(DrinkOrderDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product item)
        {
            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _context.Products.FindAsync(id);
            if (item != null)
            {
                _context.Products.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(object id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product item)
        {
            _context.Products.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProductNameExistsAsync(string ProductName, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Products
                    .AnyAsync(c => c.ProductName == ProductName && c.ProductId != excludeId.Value);
            }
            return await _context.Products
                .AnyAsync(c => c.ProductName == ProductName);
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.ProductId == id);
        }

    }
}
