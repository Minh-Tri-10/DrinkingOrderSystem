using BLL.Services.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.interfaces;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Category item) => await _repo.AddAsync(item);
        public async Task DeleteAsync(object id) => await _repo.DeleteAsync(id);
        public async Task<IEnumerable<Category>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Category> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);
        public async Task UpdateAsync(Category item) => await _repo.UpdateAsync(item);

        public async Task<bool> CategoryNameExistsAsync(string categoryName, int? excludeId = null)
        => await _repo.CategoryNameExistsAsync(categoryName, excludeId);

    }
}
