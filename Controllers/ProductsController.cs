using InternalManagementSystem.Api.Data;
using InternalManagementSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalManagementSystem.Api.Dtos;

namespace InternalManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll(
        [FromQuery] string? q,
        [FromQuery] string? category
        )
    {
        //（search + category）
        var query = _db.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(q))
        {
            query = query.Where(p => p.Name.Contains(q));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(p => p.Category == category);
        }

        var products = await query
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            })
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _db.Products.FindAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductDto input)
    {
        var product = new Product
        {
            Name = input.Name,
            Price = input.Price,
            Category = input.Category
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product is null) return NotFound();

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto input)
    {
        var product = await _db.Products.FindAsync(id);
        if (product is null) return NotFound();

        product.Name = input.Name;
        product.Price = input.Price;
        product.Category = input.Category;

        await _db.SaveChangesAsync();
        return NoContent();
    }

}
