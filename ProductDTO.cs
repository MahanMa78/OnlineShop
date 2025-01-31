using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop;

public class ProductDTO
{
    public string Title {get;set;}
    public int Quantity {get;set;}
    public double Price {get;set;}
    public bool IsActive {get;set;}
    public DateOnly DataTimeCreated {get;set;}
}
