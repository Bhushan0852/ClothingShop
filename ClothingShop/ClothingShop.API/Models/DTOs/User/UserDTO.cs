namespace ClothingShop.API.Models.DTOs.User
{
    public class UserDTO 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Nevigation Prop
        public Guid UserRoleId{ get; set; }
        public UserRoleDTO UserRole{ get; set; }
        public IEnumerable<UserLocationsDTO>? UserLocations { get; set; }
    }
}
