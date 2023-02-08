namespace ClothingShop.API.Models.Domains
{
    public class ProductSize : AuditEntity
    {
        public Guid Id { get; set; }
        public string ProductSizeDesp { get; set; }
        public int ProductSort { get; set; }

    }
}
