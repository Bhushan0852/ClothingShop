namespace ClothingShop.API.Models.Domains
{
    public class User : AuditEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Nevigation Prop
        public Guid UserRoleId { get; set; }
        public UserRole UserRole{ get; set; }
        public IEnumerable<UserLocations> UserLocations { get; set; }
    }
}
