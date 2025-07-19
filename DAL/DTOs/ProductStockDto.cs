using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    // DTOs
    public class ProductStockDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Stock { get; set; }
    }
}
