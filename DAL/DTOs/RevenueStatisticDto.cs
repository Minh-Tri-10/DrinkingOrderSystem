using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    // DTOs
    public class RevenueStatisticDto
    {
        public DateTime Period { get; set; }
        public decimal Revenue { get; set; }
    }
}
