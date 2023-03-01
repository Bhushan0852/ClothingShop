using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingShop.API.Models.Domains
{
    public class ImageModel : AuditEntity
    {
        public Guid Id { get; set; }

        //public string Title { get; set; }

        //public string ImageName { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        //public Guid ProjectId { get; set; }
    }
}
