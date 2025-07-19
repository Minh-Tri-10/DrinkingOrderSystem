//using BLL.Services.interfaces;
//using DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    public class ProductService : IProductService
//    {
//        private readonly IProductRepository _repo;

//        public ProductService(IProductRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task AddAsync(Praduct item) => await _repo.AddAsync(item);
//        public async Task DeleteAsync(object id) => await _repo.DeleteAsync(id);
//        public async Task<IEnumerable<Praduct>> GetAllAsync() => await _repo.GetAllAsync();
//        public async Task<Praduct> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);
//        public async Task UpdateAsync(Praduct item) => await _repo.UpdateAsync(item);

//    }
//}
