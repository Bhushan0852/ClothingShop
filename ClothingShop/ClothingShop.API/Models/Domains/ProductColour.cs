namespace ClothingShop.API.Models.Domains
{
    public class ProductColour : AuditEntity
    {
        public Guid Id { get; set; }
        public string ProductColourName { get; set; }
        public string ProductColourCode { get; set; }
        public int ProductColourSort { get; set; }

    }
}
