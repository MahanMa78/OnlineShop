using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.DTOs;


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
           p.CurrentCategoryId,

           CategoryTitle = p.Category.Title

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

                Category = p.Category.Title
                
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
        var category = await _context.Categories.FindAsync(dto.CategoryId);
        if (category == null)
            return NotFound("Category not found");

        Product product = new Product
        {
            Title = dto.Title,
            Quantity = dto.Quantity,
            DataTimeCreated = dto.DataTimeCreated,
            IsActive = dto.IsActive,
            Price = dto.Price,
            CurrentCategoryId = dto.CategoryId, 

        };
        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Add), dto);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDTO dto)
    {
        var category = await _context.Categories.FindAsync(dto.CategoryId);
        var exitingProduct = await _context.Products.FindAsync(id);
        if (exitingProduct == null || category == null )
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

    [HttpGet("GetFilteredProducts")]
    public async Task<IActionResult> GetFilteredProducts([FromQuery] ProductFilterDTO filter)
    {
         var query = _context.Products.AsQueryable();

    if (filter.MinPrice.HasValue)
        query = query.Where(p => p.Price >= filter.MinPrice.Value);

    if (filter.MaxPrice.HasValue)
        query = query.Where(p => p.Price <= filter.MaxPrice.Value);

        

    if (filter.CategoryId.HasValue)
        query = query.Where(p => p.CurrentCategoryId == filter.CategoryId.Value);

    if (!string.IsNullOrEmpty(filter.SortBy))
    {
        query = filter.SortBy.ToLower() switch
        {
            "price" => filter.IsDescending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
            _ => query
        };
    }
    

    if(filter.MaxQuantity.HasValue)
            query = query.Where(p => p.Quantity >= filter.MaxQuantity.Value);

    if (filter.MinQuantity.HasValue)
            query = query.Where(p => p.Quantity <= filter.MinQuantity.Value);   
    

    var products = await query.ToListAsync();
    return Ok(products);
    }
}