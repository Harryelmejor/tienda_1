using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tienda_1.Data;
using tienda_1.Models;

namespace tienda_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly TiendaContext _context;

    public SalesController(TiendaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
    {
        return await _context.Sales
            .Include(s => s.Client)
            .Include(s => s.Details)
            .ThenInclude(d => d.Product)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sale>> GetById(int id)
    {
        var sale = await _context.Sales
            .Include(s => s.Client)
            .Include(s => s.Details)
            .ThenInclude(d => d.Product)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sale == null) return NotFound();
        return sale;
    }

    [HttpPost]
    public async Task<ActionResult<Sale>> Create(Sale sale)
    {
        sale.Date = DateTime.Now;

        foreach (var detail in sale.Details)
        {
            var product = await _context.Products.FindAsync(detail.ProductId);
            if (product == null)
                return BadRequest($"Product with ID {detail.ProductId} does not exist.");

            if (product.Stock < detail.Quantity)
                return BadRequest($"Insufficient stock for '{product.Name}'. Available: {product.Stock}");

            detail.UnitPrice = product.Price;
            detail.Subtotal = detail.Quantity * detail.UnitPrice;
            product.Stock -= detail.Quantity;
        }

        sale.Total = sale.Details.Sum(d => d.Subtotal);

        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sale = await _context.Sales
            .Include(s => s.Details)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sale == null) return NotFound();

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
