using DAL.Data;
using DAL.Models;
using DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 


namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DrinkOrderDbContext _context;

        public CategoryRepository(DrinkOrderDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category item)
        {
            await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _context.Categories.FindAsync(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(object id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category item)
        {
            _context.Categories.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CategoryNameExistsAsync(string categoryName, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Categories
                    .AnyAsync(c => c.CategoryName == categoryName && c.CategoryId != excludeId.Value);
            }
            return await _context.Categories
                .AnyAsync(c => c.CategoryName == categoryName);
        }
    }
}
