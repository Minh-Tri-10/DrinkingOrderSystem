//using DAL.Data;
//using DAL.Models;
//using DAL.Repositories.interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL.Repositories
//{
//    public class OrderRepository : IOrderRepository
//    {
//        private readonly DrinkOrderDbContext _context;

//        public OrderRepository(DrinkOrderDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Order>> GetAllAsync()
//        {
//            return await _context.Orders
//                                 .Include(o => o.User) // ✅ lấy kèm thông tin User
//                                 .ToListAsync();
//        }


//        public async Task<Order> GetByIdAsync(object id)
//        {
//            return await _context.Orders
//                                 .Include(o => o.User) // Include User thông tin
//                                 .FirstOrDefaultAsync(o => o.OrderId == (int)id);
//        }

//        public async Task UpdateAsync(Order item)
//        {
//            _context.Orders.Update(item);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
