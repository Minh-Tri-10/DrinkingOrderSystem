using DAL.Data;
using DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DTOs;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    // DAL/Repositories/StatisticRepository.cs
    public class StatisticRepository : IStatisticRepository
    {
        private readonly DrinkOrderDbContext _context;
        public StatisticRepository(DrinkOrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductStatisticDto>> GetProductStatistics(DateTime? from, DateTime? to)
        {
            var query = _context.OrderItems
                .Include(oi => oi.Product)
                .Include(oi => oi.Order)
                .AsQueryable();

            if (from.HasValue)
                query = query.Where(oi => oi.Order.OrderDate >= from.Value);
            if (to.HasValue)
                query = query.Where(oi => oi.Order.OrderDate <= to.Value);

            var stats = await query
                .GroupBy(oi => new { oi.ProductId, oi.Product.ProductName })
                .Select(g => new ProductStatisticDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    TotalSold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .ToListAsync();

            return stats;
        }

        public async Task<IEnumerable<ProductStockDto>> GetStockProducts()
        {
            return await _context.Products
                .Select(p => new ProductStockDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Stock = p.Stock
                }).ToListAsync();
        }

        public async Task<IEnumerable<ProductStatisticDto>> GetBestSellerProducts(DateTime? from, DateTime? to)
        {
            var stats = await GetProductStatistics(from, to);
            var maxSold = stats.Max(x => x.TotalSold);
            return stats.Where(x => x.TotalSold == maxSold).ToList();
        }
        public async Task<IEnumerable<RevenueStatisticDto>> GetRevenueStatistics(string? by, DateTime? from, DateTime? to)
        {
            var query = _context.Orders.AsQueryable();

            if (from.HasValue)
                query = query.Where(o => o.OrderDate >= from.Value);
            if (to.HasValue)
                query = query.Where(o => o.OrderDate <= to.Value);

            if (by == "day")
            {
                return await query
                    .GroupBy(o => o.OrderDate.Value.Date)
                    .Select(g => new RevenueStatisticDto
                    {
                        Period = g.Key,
                        Revenue = g.Sum(x => x.TotalAmount ?? 0)
                    })
                    .OrderBy(x => x.Period)
                    .ToListAsync();
            }
            if (by == "month")
            {
                return await query
                    .GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month })
                    .Select(g => new RevenueStatisticDto
                    {
                        Period = new DateTime(g.Key.Year, g.Key.Month, 1),
                        Revenue = g.Sum(x => x.TotalAmount ?? 0)
                    })
                    .OrderBy(x => x.Period)
                    .ToListAsync();
            }
            // Default: tổng
            return await query
                .GroupBy(o => 1)
                .Select(g => new RevenueStatisticDto
                {
                    Period = DateTime.Today,
                    Revenue = g.Sum(x => x.TotalAmount ?? 0)
                })
                .ToListAsync();
        }

        public async Task<decimal> GetTotalRevenue(DateTime? from, DateTime? to)
        {
            var query = _context.Orders.AsQueryable();
            if (from.HasValue)
                query = query.Where(o => o.OrderDate >= from.Value);
            if (to.HasValue)
                query = query.Where(o => o.OrderDate <= to.Value);

            return await query.SumAsync(o => o.TotalAmount ?? 0);
        }

    }

}
