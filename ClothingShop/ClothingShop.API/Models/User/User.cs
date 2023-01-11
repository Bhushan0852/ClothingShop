namespace ClothingShop.API.Models.User
{
    public class User : AuditEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Nevigation Prop
        public UserRole UserRole{ get; set; }
        public IEnumerable<UserLocations> UserLocations { get; set; }
    }
}
