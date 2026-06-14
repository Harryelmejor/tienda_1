using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tienda_1.Data;
using tienda_1.Models;

namespace tienda_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly TiendaContext _context;

    public ClientsController(TiendaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAll()
    {
        return await _context.Clients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();
        return client;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Create(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Client updated)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();

        client.Name = updated.Name;
        client.Identification = updated.Identification;
        client.Phone = updated.Phone;
        client.Address = updated.Address;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
