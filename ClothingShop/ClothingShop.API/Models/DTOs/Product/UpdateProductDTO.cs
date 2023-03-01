namespace ClothingShop.API.Models.DTOs
{
    public class UpdateProductDTO
    {
        //public string SKUCode { get; set; }
        public Guid Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDitails { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public int Discount { get; set; }
        //public Guid ProductBrandId { get; set; }
        //public Guid ProductSizeId { get; set; }
        //public Guid ProductColourId { get; set; }
        //public IEnumerable<CreateProductImagesDTO> ProductImages{ get; set; }
    }
}
