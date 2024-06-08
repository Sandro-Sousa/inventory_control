
namespace Service.DTOs
{
    public class ProductDTO
    {
        public int? IdProduct { get; set; } = 0;
        public string? Description { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal? SaleValue { get; set; }

        public int? StockBalance { get; set; }
    }
}
