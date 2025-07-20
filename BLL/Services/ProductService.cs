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
    public class ProductService : IProductService
    { 
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task AddAsync(Product item) => await _repo.AddAsync(item);
    public async Task DeleteAsync(object id) => await _repo.DeleteAsync(id);
    public async Task<IEnumerable<Product>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Product> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Product item) => await _repo.UpdateAsync(item);

    public async Task<bool> ProductNameExistsAsync(string ProductName, int? excludeId = null)
    => await _repo.ProductNameExistsAsync(ProductName, excludeId);

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
=> await _repo.GetAllWithCategoryAsync();

    public async Task<Product> GetByIdWithCategoryAsync(int id)
        => await _repo.GetByIdWithCategoryAsync(id);

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        => await _repo.GetAllCategoriesAsync();

    public async Task<bool> ExistsAsync(int id)
        => await _repo.ExistsAsync(id);

}
}
