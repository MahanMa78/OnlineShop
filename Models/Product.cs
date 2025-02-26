using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models;

public class Product
{
    public int ProductId {get;set;}
    public string Title {get;set;}
    public int Quantity {get;set;}
    public double Price {get;set;}
    public bool IsActive {get;set;}
    public int CurrentCategoryId { get; set; }
    public DateOnly DataTimeCreated {get;set;}
    public Category Category {get;set;}
    
}