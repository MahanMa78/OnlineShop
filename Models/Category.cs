using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = default!;
        public string? Description {get; set;}
        public ICollection<Product>? Products {get; set;}
    }
}