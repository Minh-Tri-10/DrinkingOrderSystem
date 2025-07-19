using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOs;

namespace BLL.Services.interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<ProductStatisticDto>> GetProductStatistics(DateTime? from, DateTime? to);
        Task<IEnumerable<ProductStatisticDto>> GetBestSellerProducts(DateTime? from, DateTime? to);
        Task<IEnumerable<ProductStockDto>> GetStockProducts();
        Task<IEnumerable<RevenueStatisticDto>> GetRevenueStatistics(string? by, DateTime? from, DateTime? to);
        Task<decimal> GetTotalRevenue(DateTime? from, DateTime? to);
    }
}
