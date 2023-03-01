
namespace ClothingShop.API.Models.DTOs
{
    public class FileDetailsDTO
    {

        public Guid ID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        public Guid ProductId { get; set; }


    }
}
