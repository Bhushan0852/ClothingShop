namespace ClothingShop.API.Models.DTOs
{
    public class SearchProductDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }

    }
}
