namespace ClothingShop.API.Models.Domains
{
    public class Product : AuditEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }

    }
}
