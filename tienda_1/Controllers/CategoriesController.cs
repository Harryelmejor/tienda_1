using Microsoft.AspNetCore.Mvc;
using tienda_1.Data;
using tienda_1.Models;

namespace tienda_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetAll()
    {
        return Ok(InMemoryData.Categories);
    }

    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = InMemoryData.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        category.Id = InMemoryData.NextCategoryId;
        InMemoryData.Categories.Add(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Category updated)
    {
        var category = InMemoryData.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return NotFound();
        category.Name = updated.Name;
        category.Description = updated.Description;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = InMemoryData.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return NotFound();
        InMemoryData.Categories.Remove(category);
        return NoContent();
    }
}
