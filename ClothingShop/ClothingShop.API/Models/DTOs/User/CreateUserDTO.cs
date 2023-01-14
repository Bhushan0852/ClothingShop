namespace ClothingShop.API.Models.DTOs.User
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid UserRoleId { get; set; }
        //public UserRoledto UserRole { get; set; }
        public CreateUserLocation CreateUserLocation{ get; set; }
    }

    //public class UserRoledto
    //{
    //    public Guid UserRoleId { get; set; } 
    //    //public string Role { get; set; }
    //}
    public class CreateUserLocation
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string AddressLane1 { get; set; }
        public string AddressLane2 { get; set; }
        public string AddressLane3 { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsPrimary { get; set; } = true;
        //public Guid UserId { get; set; }
    }
}
