using AutoMapper;
using ClothingShop.API.Repository.IEFRepository.User;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IEFUserRepository userRepository;
        private readonly IMapper mapper;

        public LoginController(IEFUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            var users = userRepository.GetAllAsnyc();
            var data = mapper.Map<List<Models.DTOs.User.UserDTO>>(users.Result);
            return Ok(data);
        }
        [HttpPost("create_user")]
        public async Task<IActionResult> CreateNewUser(Models.DTOs.User.CreateUserDTO createUser)
        {
            var data = await userRepository.CreateAsync(createUser);
            if (data == null)
            {
                return BadRequest("Request Failed");
            }
            var userData = mapper.Map<Models.DTOs.User.UserDTO>(data);
            return Ok(userData);
        }

        [HttpPost("create-userlocation")]
        public async Task<IActionResult> CreateUserLocation(Models.DTOs.User.CreateUserLocationsDTO userLocationsDTO)
        {
            var data = await userRepository.CreateLocationAsync(userLocationsDTO);
            if (data == null)
            {
                return BadRequest("Request Failed");
            }
            var resonce = mapper.Map<Models.DTOs.User.CreateUserLocationsDTO>(data);
            return Ok(resonce);
        }

    }
}
