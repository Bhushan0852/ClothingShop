namespace ClothingShop.API.Models.Domains
{
    public class Product : AuditEntity
    {
        public Guid Id { get; set; }
        public string SKUCode { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDitails { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public string VendorCode { get; set; }

        public Guid ProductBrandId { get; set; }
        public ProductBrands ProductBrand { get; set; }

        public Guid ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }

        public Guid ProductColourId { get; set; }
        public ProductColour ProductColour{ get; set; }

        public IEnumerable<FileDetails> FileDetails{ get; set; }

        public string IncValue { get; set; }
    }
}
