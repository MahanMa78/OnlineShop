using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace OnlineShop;


public class ShopDbContext : IdentityDbContext<User>
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShopDb;Trusted_Connection=True;");
    }


    protected override void OnModelCreating(ModelBuilder Builder)
    {
        base.OnModelCreating(Builder);
        
    }
}
