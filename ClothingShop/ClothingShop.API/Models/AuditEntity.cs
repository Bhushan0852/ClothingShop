namespace ClothingShop.API.Models
{
    public class AuditEntity
    {
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public string CreatedByTimeStamp { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedByTimeStamp { get; set; }
    }
}
