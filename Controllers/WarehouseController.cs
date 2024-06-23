using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehousesController : ControllerBase
{
  private readonly WarehouseContext _context;

  public WarehousesController(WarehouseContext context)
  {
    _context = context;
  }

  // GET: api/warehouses
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
  {
    return await _context.Warehouses.ToListAsync();
  }

  // GET: api/warehouses/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
  {
    var warehouse = await _context.Warehouses.FindAsync(id);

    if (warehouse == null)
    {
      return NotFound();
    }

    return warehouse;
  }

  // POST api/warehouses
  [HttpPost]
  public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
  {
    _context.Warehouses.Add(warehouse);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.Id }, warehouse);
  }

  // PUT api/warehouses/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutWarehouse(int id, Warehouse warehouse)
  {
    if (id != warehouse.Id)
    {
      return BadRequest();
    }

    _context.Entry(warehouse).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // DELETE api/warehouses/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteWarehouse(int id)
  {
    var warehouse = await _context.Warehouses.FindAsync(id);

    if (warehouse == null)
    {
      return NotFound();
    }

    _context.Warehouses.Remove(warehouse);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // dummy endpoint to test the database connection
  [HttpGet("test")]
  public string Test()
  {
    return "Hello World!";
  }
}