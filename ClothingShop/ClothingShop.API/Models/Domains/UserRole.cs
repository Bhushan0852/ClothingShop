namespace ClothingShop.API.Models.Domains
{
    public class UserRole : AuditEntity
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
