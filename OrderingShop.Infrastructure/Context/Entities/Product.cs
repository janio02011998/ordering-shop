using OrderingShop.Infrastructure.Conxtext.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingShop.Infrastructure.Context.Entities
{
    [Table("PRODUCT")]
    public class Product : BaseEntity
    {
        [Column("NAME")]
        public string Name { get; set; } = string.Empty;
        [Column("DESCRIPTION")]
        public string Description { get; set; } = string.Empty;
        [Column("PRICE")]
        public decimal Price { get; set; }
        [Column("STOCK")]
        public int Stock { get; set; }
    }
}
