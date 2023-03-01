namespace ClothingShop.API.Models.DTOs.User
{
    public class UpdateUserLocationDTO
    {
        public Guid Id { get; set; }
        public string AddressLane1 { get; set; }
        public string AddressLane2 { get; set; }
        public string AddressLane3 { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsPrimary { get; set; }
    }
    public class UpdateUserLocationFromCartDTO
    {
        public Guid Id { get; set; }
        public string AddressLane1 { get; set; }
        public string AddressLane2 { get; set; }
        public string AddressLane3 { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
