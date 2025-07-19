using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.DTOs;
using DAL.Repositories.interfaces;
namespace DAL.Repositories.interfaces
{
    // DAL/Repositories/interfaces/IStatisticRepository.cs
    public interface IStatisticRepository
    {
        // Thống kê số lượng bán ra cho từng sản phẩm, trong khoảng thời gian
        Task<IEnumerable<ProductStatisticDto>> GetProductStatistics(DateTime? from, DateTime? to);

        // Thống kê sản phẩm bán chạy nhất (có thể trả về 1 hoặc nhiều sp nếu đồng số lượng)
        Task<IEnumerable<ProductStatisticDto>> GetBestSellerProducts(DateTime? from, DateTime? to);

        // Lấy sản phẩm còn tồn kho
        Task<IEnumerable<ProductStockDto>> GetStockProducts();
        // ... các hàm trên
        Task<IEnumerable<RevenueStatisticDto>> GetRevenueStatistics(string? by, DateTime? from, DateTime? to);
        Task<decimal> GetTotalRevenue(DateTime? from, DateTime? to);
    }

}
