using ClothingShop.API.Repository.IEFRepository.Product;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IEFProductRepository productRepository;

        public ProductController(IEFProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("Get-product-list")]
        public IActionResult GetAll()
        {
            var data = productRepository.GetAll();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
