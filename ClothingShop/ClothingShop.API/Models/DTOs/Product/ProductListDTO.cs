namespace ClothingShop.API.Models.DTOs
{
    public class ProductListDTO : AuditEntity
    {
        public Guid Id { get; set; }
        public string SKUCode { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDitails { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public string VendorCode { get; set; }

        public Guid ProductBrandId { get; set; }
        public Guid ProductSizeId { get; set; }

        public Guid ProductColourId { get; set; }
    }
}
