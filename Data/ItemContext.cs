using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class ItemContext : DbContext
  {
    public ItemContext(DbContextOptions<ItemContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
  }
}