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
        //public float? MinRating {get;set;}
        //public float? MaxRating {get;set;}
        public int? CategoryId  {get;set;}
        public string? SortBy {get;set;}
        public bool IsDescending {get;set;} = false;
        public int? MaxQuantity { get;set;}
        public int? MinQuantity { get; set; }
    }
}