using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DTOs;

public class ProductDTO
{
    public string Title { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public DateOnly DataTimeCreated { get; set; }
    public int CategoryId { get; set; }
}
