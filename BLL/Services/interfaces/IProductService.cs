using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(object id);
        Task AddAsync(Product item);
        Task UpdateAsync(Product item);
        Task DeleteAsync(object id);
        Task<bool> ProductNameExistsAsync(string ProductName, int? excludeId = null);

        Task<IEnumerable<Product>> GetAllWithCategoryAsync();
        Task<Product> GetByIdWithCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<bool> ExistsAsync(int id);

    }
}
