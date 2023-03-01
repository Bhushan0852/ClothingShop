using ClothingShop.API.Repository.IEFRepository.Product;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{

    [ApiController]
    [Route("api/addtocart")]
    public class AddToCartController : Controller
    {
        private readonly IEFProductRepository productRepository;

        public AddToCartController(IEFProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("product-added-by-user")]
        public IActionResult UserAddedProduct(Guid userId, Guid productId, int quantity)
        {
            var data = productRepository.UserAddedProduct(userId,productId, quantity);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("remove-product-added-by-user")]
        public IActionResult RemoveUserAddedProduct(Guid userId, Guid productId)
        {
            var data = productRepository.RemoveUserAddedProduct(userId, productId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("placed-order")]
        public IActionResult PlaceOrder(Guid userId, Guid productId)
        {
            var data = productRepository.PlaceOrder(userId, productId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.Result);
        }
    }
}
