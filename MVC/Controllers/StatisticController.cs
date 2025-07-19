using Microsoft.AspNetCore.Mvc;
using DAL.DTOs;
using BLL.Services.interfaces;

namespace MVC.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statService;

        public StatisticController(IStatisticService statService)
        {
            _statService = statService;
        }

        // Thống kê sản phẩm bán ra
        public async Task<IActionResult> ProductStatistic(DateTime? from, DateTime? to)
        {
            var stats = await _statService.GetProductStatistics(from, to);
            var bestSellers = await _statService.GetBestSellerProducts(from, to);
            var stocks = await _statService.GetStockProducts();

            ViewBag.BestSellers = bestSellers;
            ViewBag.Stocks = stocks;

            return View(stats); // View nhận model là IEnumerable<ProductStatisticDto>
        }

        // Thống kê doanh thu
        public async Task<IActionResult> RevenueStatistic(string? by, DateTime? from, DateTime? to)
        {
            var revenueStats = await _statService.GetRevenueStatistics(by, from, to);
            var total = await _statService.GetTotalRevenue(from, to);

            ViewBag.TotalRevenue = total;
            return View(revenueStats); // View nhận model là IEnumerable<RevenueStatisticDto>
        }
    }
}