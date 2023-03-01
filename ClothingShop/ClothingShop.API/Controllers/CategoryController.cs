using ClothingShop.API.IEFRepository.Category;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly IEFCategoryRepository categoryRepository;

        public CategoryController(IEFCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-by-search-string")]
        public IActionResult GetProductsbySearch(string searchString)
        {
            var data = categoryRepository.GetProductsbySearch(searchString);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.Result.ToList());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-list")]
        public IActionResult GetProductList(Models.DTOs.Category.SearchCategory searchCategory)
        {
            var data = categoryRepository.GetProductList(searchCategory);

            if(!data.IsCompleted)
            {
                return BadRequest();
            }
            return Ok(data.Result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-product-preview-detail")]
        public IActionResult GetProductPreview(Guid guid)
        {
            var data = categoryRepository.GetProductPreview(guid);
            if (data.Result == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }
    }
}
