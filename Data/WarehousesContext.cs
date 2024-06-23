using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class WarehouseContext : DbContext
  {
    public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
    {
    }

    public DbSet<Warehouse> Warehouses { get; set; }
  }
}