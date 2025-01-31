using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models;

public class Order
{
    public int OrderId {get;set;}
    public Customer Customer {get;set;}
    public bool IsPaid {get;set;} 
}