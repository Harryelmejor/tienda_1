using Microsoft.AspNetCore.Mvc;
using tienda_1.Data;
using tienda_1.Models;

namespace tienda_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll([FromQuery] int? categoryId)
    {
        var products = InMemoryData.Products.AsEnumerable();
        if (categoryId.HasValue)
            products = products.Where(p => p.CategoryId == categoryId.Value);
        return Ok(products.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = InMemoryData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        product.Id = InMemoryData.NextProductId;
        InMemoryData.Products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updated)
    {
        var product = InMemoryData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        product.Name = updated.Name;
        product.Description = updated.Description;
        product.Price = updated.Price;
        product.Stock = updated.Stock;
        product.CategoryId = updated.CategoryId;
        product.ImageUrl = updated.ImageUrl;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = InMemoryData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        InMemoryData.Products.Remove(product);
        return NoContent();
    }
}
