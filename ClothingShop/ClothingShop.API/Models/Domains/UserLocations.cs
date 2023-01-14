namespace ClothingShop.API.Models.Domains
{
    public class UserLocations : AuditEntity
    {
        public Guid Id { get; set; }
        public string AddressLane1 { get; set; }
        public string AddressLane2 { get; set; }
        public string AddressLane3 { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsPrimary { get; set; }

        //Nevigation Prop
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
