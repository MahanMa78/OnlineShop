using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.DTOs;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ShopDbContext _context;

    public CategoryController(ILogger<CategoryController> logger, ShopDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    //[HttpGet]
    //public async Task<ActionResult<List<Category>>> GetAll()
    //{
    //    var categories = await _context.Categories
    //        .Select(c => new CategoryDTO()
    //        {
    //            Id = c.CategoryId,
    //            Description = c.Description,
    //            Title = c.Title,
    //            Products = c.Products.Select(p => new ProductDTO()
    //            {
    //                Title = p.Title,
    //                Price =p.Price,
    //                DataTimeCreated = p.DataTimeCreated,
    //                IsActive = p.IsActive,
    //                Quantity = p.Quantity,
    //                CategoryId = c.CategoryId
    //            }).ToList()

    //        }).ToListAsync();

    //    return Ok(categories);
    //}


    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategory()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDTO()
            {
                Id = c.CategoryId,
                Title = c.Title,
                Description = c.Description
            }).ToListAsync();

        return Ok(categories);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
        //var categoryWithProducts = await _context.Categories.Where(c => c.CategoryId == id)
        //    .Select(c => new
        //    {
        //        c.CategoryId,
        //        c.Title,
        //        c.Description,
        //        Products = c.Products.Select(p => new
        //        {
        //            p.ProductId,
        //            p.Title,
        //            p.Quantity,
        //            p.Price,
        //            p.IsActive,
        //            p.DataTimeCreated
        //        }).ToList()
        //    }).FirstOrDefaultAsync();

        //   if(categoryWithProducts == null)
        //    return NotFound();

        var categoryWithProducts = await _context.Categories.Where(c => c.CategoryId == id)
            .Select(c => new CategoryDTO()
            {
                Id = c.CategoryId,
                Description = c.Description,
                Title = c.Title,
                Products = c.Products.Select(p => new ProductDTO()
                {
                    Title = p.Title,
                    Price = p.Price,
                    DataTimeCreated = p.DataTimeCreated,
                    IsActive = p.IsActive,
                    Quantity = p.Quantity,
                    CategoryId = c.CategoryId

                }).ToList()
            }).FirstOrDefaultAsync();

        if (categoryWithProducts == null)
            return NotFound();

        return Ok(categoryWithProducts);
    }


    [HttpPost]
    public async Task<ActionResult<Category>> Add(CreateUpdateCategoryCommand dto)
    {
        Category cagtegory = new Category
        {
            Title = dto.Title,
            Description = dto.Description,

        };
        _context.Categories.Add(cagtegory);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Add), dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateUpdateCategoryCommand dto)
    {
        var exitingCategory = await _context.Categories.FindAsync(id);
        if (exitingCategory == null) return NotFound();

        exitingCategory.Title = dto.Title;
        exitingCategory.Description = dto.Description;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}