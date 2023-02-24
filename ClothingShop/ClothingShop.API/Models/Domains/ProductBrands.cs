namespace ClothingShop.API.Models.Domains
{
    public class ProductBrands : AuditEntity
    {
        public Guid Id { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
    }
}
