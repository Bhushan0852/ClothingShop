namespace ClothingShop.API.Models.DTOs
{
    public class CreateProductImagesDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; }

    }
}
