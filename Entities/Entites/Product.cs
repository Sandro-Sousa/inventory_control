using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Entites
{
    public class Product
    {
        [Key]
        public int? IdProduct { get; set; }

        [Required]
        public string? Description { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PurchasePrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? SaleValue { get; set; }

        [Required]
        public int? StockBalance { get; set; }
    }
}
