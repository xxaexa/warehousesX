using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("warehouses")]
  public class Warehouse
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

  }
}