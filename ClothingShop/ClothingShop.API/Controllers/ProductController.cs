using ClothingShop.API.Repository.IEFRepository.Product;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IEFProductRepository productRepository;

        public ProductController(IEFProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("get-product-list")]
        public IActionResult GetAll()
        {
            var data = productRepository.GetAll();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("search-product-list")]
        public IActionResult SerachProduct(Models.DTOs.SearchProductDTO searchProduct)
        {
            var data = productRepository.SearchProduct(searchProduct);  
            if(data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct()
        {
            return Ok();
        }
    }
}
