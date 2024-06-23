using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("items")]
  public class Item
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("price")]
    public string Price { get; set; }

    [Column("qty")]
    public int Qty { get; set; }

    [Column("exp_date")]
    public string Exp_Date { get; set; }

    [Column("id_warehouse")]
    public string Id_warehouse { get; set; }
  }
}