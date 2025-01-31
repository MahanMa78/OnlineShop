using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ShopDbContext _context;

    public ProductController(ShopDbContext context)
    {
        _context = context;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _context.Products
       .Select(p => new
       {
           p.ProductId,
           p.Title,
           p.Quantity,
           p.Price,
           p.IsActive,
           p.DataTimeCreated,
           
       })
       .ToListAsync();

        return Ok(products);

    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var product = await _context.Products.Where(p => p.ProductId == id)
            .Select(p => new
            {
                p.ProductId,
                p.Title,
                p.Quantity,
                p.DataTimeCreated,
                p.IsActive,
                p.Price,
                
            })
                .FirstOrDefaultAsync();


        if (product == null)
            return NotFound("Product Not Found");

        return Ok(product);
    }


    // POST action
    [HttpPost]
    public async Task<IActionResult> Add(ProductDTO dto)
    {

        Product product = new Product
        {
            Title = dto.Title,
            Quantity = dto.Quantity,
            DataTimeCreated = dto.DataTimeCreated,
            IsActive = dto.IsActive,
            Price = dto.Price

        };
        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Add), dto);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDTO dto)
    {
        var exitingProduct = await _context.Products.FindAsync(id);
        if (exitingProduct == null )
            return NotFound("Product not found");

        exitingProduct.Title = dto.Title;
        exitingProduct.Quantity = dto.Quantity;
        exitingProduct.IsActive = dto.IsActive;
        exitingProduct.Price = dto.Price;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}