namespace ClothingShop.API.Models.Domains
{
    public class UserProducts : AuditEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ProductSizeId{ get; set; }
        public ProductSize ProductSize{ get; set; }
    }
}
