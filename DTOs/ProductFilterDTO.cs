using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DTOs
{
    public class ProductFilterDTO
    {
        public decimal? MinPrice {get;set;}
        public decimal? MaxPrice { get; set; }
        public double? MinRating {get;set;}
        public double? MaxRating {get;set;}
        public int? CategoryId  {get;set;}
        public string? SortBy {get;set;}
        public bool IsDecending {get;set;} = false;
    }
}