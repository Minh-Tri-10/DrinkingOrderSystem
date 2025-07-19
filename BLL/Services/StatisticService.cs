using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.interfaces;
using DAL.DTOs;
using BLL.Services.interfaces;
namespace BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _repo;

        public StatisticService(IStatisticRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductStatisticDto>> GetProductStatistics(DateTime? from, DateTime? to)
            => await _repo.GetProductStatistics(from, to);

        public async Task<IEnumerable<ProductStatisticDto>> GetBestSellerProducts(DateTime? from, DateTime? to)
            => await _repo.GetBestSellerProducts(from, to);

        public async Task<IEnumerable<ProductStockDto>> GetStockProducts()
            => await _repo.GetStockProducts();

        public async Task<IEnumerable<RevenueStatisticDto>> GetRevenueStatistics(string? by, DateTime? from, DateTime? to)
            => await _repo.GetRevenueStatistics(by, from, to);

        public async Task<decimal> GetTotalRevenue(DateTime? from, DateTime? to)
            => await _repo.GetTotalRevenue(from, to);
    }
}
