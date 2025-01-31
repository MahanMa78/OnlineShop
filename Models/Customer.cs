using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models;

public class Customer
{
    public int CustomerId {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string UserName {get;set;}    
    public string Email {get;set;}
    public int PhoneNumber {get;set;}
}