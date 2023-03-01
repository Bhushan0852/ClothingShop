using AutoMapper;
using ClothingShop.API.Repository.IEFRepository.Product;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IEFProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IEFProductRepository productRepository , IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-list")]
        public IActionResult GetAll()
        {
            var data = productRepository.GetAllAsync();
            if (data == null)
            {
                return NotFound();
            }
            var data1 = mapper.Map<List<Models.DTOs.ProductListDTO>>(data.Result);
            return Ok(data1);
        }

        

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromForm]Models.DTOs.CreateProductDTO createProductDTO, List<IFormFile> fileData)
        {
            var data = productRepository.CreateProduct(createProductDTO, fileData);
            if (data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-preview-detail")]
        public IActionResult GetProductPreview(Guid guid)
        {
            var data = productRepository.GetProductPreview(guid);
            if (data.Result == null)
            {
                return NotFound();
            }
            var data1 = mapper.Map<Models.DTOs.ProductListDTO>(data.Result);
            return Ok(data1);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-detail")]
        public IActionResult GetProductDetail(Guid guid)
        {
            var data = productRepository.GetProductDetail(guid);
            if (data.Result == null)
            {
                return NotFound();
            }
            var data1 = mapper.Map<Models.DTOs.ProductListDTO>(data.Result);
            return Ok(data1);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("remove-product-data")]
        public IActionResult RemoveProduct(Guid guid)
        {
          var data = productRepository.RemoveProduct(guid);
            if (data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update-product")]
        public IActionResult UpdateProduct(Models.DTOs.UpdateProductDTO updateProduct)
        {
            var data = productRepository.UpdateProduct(updateProduct);
            if (data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("search-product-list")]
        public IActionResult SearchSkuProducts(string skuName)
        {
            var data = productRepository.SearchSkuProducts(skuName);
            if (data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }
    }
}
