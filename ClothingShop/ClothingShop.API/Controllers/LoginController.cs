using AutoMapper;
using ClothingShop.API.Repository.IEFRepository.User;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IEFUserRepository userRepository;
        private readonly IMapper mapper;

        public LoginController(IEFUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            var users = userRepository.GetAllAsnyc();
            var data = mapper.Map<List<Models.DTOs.User.UserDTO>>(users.Result);
            return Ok(data);
        }

        //[HttpGet("get-userlocation-byuser-id")]
        //public async Task<IActionResult> GetUserandUserLocationsByUserId(Guid guid)
        //{
        //    var response = await userRepository.GetUserLocationByUserAsync(guid);
        //    if (response == null)
        //    {
        //        return BadRequest("Request Failed");
        //    }
        //    var data = mapper.Map<Models.DTOs.User.UserDTO>(response);
        //    return Ok(data);
        //}

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateNewUser(Models.DTOs.User.CreateUserDTO createUser)
        {
            var data = await userRepository.CreateAsync(createUser);
            if (data == null)
            {
                return BadRequest("Request Failed");
            }
            //var userData = mapper.Map<Models.DTOs.User.UserAndUserLocationDTO>(data);
            return Ok("User Added Sucessfully");
        }

        //[HttpPost("create-userlocation")]
        //public async Task<IActionResult> CreateUserLocation(Models.DTOs.User.CreateUserLocationsDTO userLocationsDTO)
        //{
        //    var data = await userRepository.CreateLocationAsync(userLocationsDTO);
        //    if (data == null)
        //    {
        //        return BadRequest("Request Failed");
        //    }
        //    //var resonce = mapper.Map<Models.DTOs.User.CreateUserLocationsDTO>(data);
        //    return Ok("Added User Location Sucessfully");
        //}

        //[HttpPut("Update-UserLocation")]
        //public async Task<IActionResult> UpdateUserLocation(Models.DTOs.User.UpdateUserLocationDTO updateUserLocation)
        //{
        //    var response = await userRepository.UpdateUserLocationAsync(updateUserLocation);
        //    if(response == null)
        //    {
        //        return BadRequest("Request Failed");
        //    }
        //    //var Data = mapper.Map<Models.DTOs.User.UpdateUserLocationDTO>(responce);
        //    return Ok(response);
        //}

        //[HttpDelete("remove-user")]
        //public async Task<IActionResult> RemoveUser(Guid guid)
        //{
        //    var response = await userRepository.DeleteUserAsync(guid); 
        //    if(!response)
        //    {
        //        return BadRequest("Request Failed");
        //    }
        //    return Ok("User Deleted sucessfully");
        //}

        //[HttpDelete("remove-user-location")]
        //public async Task<IActionResult> RemoveUserLocation(Guid guid)
        //{
        //    var response = await userRepository.DeleteUserLoacationAsync(guid);
        //    if (!response)
        //    {
        //        return BadRequest("Request Failed");
        //    }
        //    return Ok("User Deleted sucessfully");
        //}

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("get-user-login")]
        public async Task<IActionResult> GetLoginUser(Models.DTOs.User.LoginUser loginUser)
        {
            var result =await userRepository.LoginUser(loginUser);
            if(result == null)
            {
                return BadRequest("Request Failed");
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(Models.DTOs.User.LoginUser loginUser)
        {
            var result = await userRepository.Resetpassword(loginUser);
            if (result == null)
            {
                return BadRequest("Request Failed");
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update-user-location-from-cart-screen")]
        public async Task<IActionResult> UpdateUserLocationFromCart(Models.DTOs.User.UpdateUserLocationFromCartDTO updateUserLocation)
        {
            var response = await userRepository.UpdateUserLocationFromCartAsync(updateUserLocation);
            if (response == null)
            {
                return BadRequest("Request Failed");
            }
            //var Data = mapper.Map<Models.DTOs.User.UpdateUserLocationDTO>(responce);
            return Ok(response);
        }
    }
}
