namespace ClothingShop.API.Models.DTOs.Category
{
    public class SearchCategory
    {
        public Guid? ProductBrandId { get; set; } = Guid.NewGuid();
        public Guid? ProductSizeId { get; set; } = Guid.NewGuid();
        public Guid? ProductColourId { get; set; } = Guid.NewGuid();
        public int? PriceRange { get; set; }
        public bool sort { get; set; } = false; // asending
    }
}
