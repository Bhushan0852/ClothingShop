
namespace ClothingShop.API.Models.Domains
{
    public class FileDetails : AuditEntity
    {

        public Guid ID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        public Guid ProductId { get; set; }

        public Product Product{ get; set; }
    }
}
