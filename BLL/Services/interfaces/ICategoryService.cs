using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(object id);
        Task AddAsync(Category item);
        Task UpdateAsync(Category item);
        Task DeleteAsync(object id);
        Task<bool> CategoryNameExistsAsync(string categoryName, int? excludeId = null);

    }
}
