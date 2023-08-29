
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private GeneralStoreDbContext _db;
    public ProductController(GeneralStoreDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest req)
    {
        Product newProduct = new()
        {
            Name = req.Name,
            Price = req.Price,
            QuantityInStock = req.Quantity
        };

        _db.Products.Add(newProduct);
        await _db.SaveChangesAsync();

        return Ok(newProduct);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _db.Products.ToListAsync();
        return Ok(products);
    }
}