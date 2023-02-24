namespace ClothingShop.API.Models.Domains
{
    public class ProductSize : AuditEntity
    {
        public Guid Id { get; set; }
        public string ProductSizeCode { get; set; }
        public string ProductSizeDesp { get; set; }
        public int ProductSizeSort { get; set; }

    }
}
