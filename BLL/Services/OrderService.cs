//using BLL.Services.interfaces;
//using DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IOrderRepository _repo;

//        public OrderService(IOrderRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task<IEnumerable<Order>> GetAllAsync() => await _repo.GetAllAsync();
//        public async Task<Order> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);
//        public async Task UpdateAsync(Order item) => await _repo.UpdateAsync(item);
//    }
//}
