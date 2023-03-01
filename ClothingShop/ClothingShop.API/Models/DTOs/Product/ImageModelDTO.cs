using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingShop.API.Models.DTOs
{
    public class ImageModelDTO 
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Guid ProjectId { get; set; }
    }
}
