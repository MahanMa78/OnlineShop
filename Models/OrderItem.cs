using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models;

public class OrderItem
{
    public int OrderItemId {get;set;}
    public Order Order {get;set;}
    public Product Product {get;set;}
    public int Quantity {get;set;}
    public int Price {get;set;}
}