using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [Route("User")]
        public IActionResult AddUser([FromBody] CreateUserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("The request's body is null.");
            }
            try
            {
                _userServices.AddUser(userDTO);
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"A user with the username {userDTO.Username.ToUpper()} already exists and can't store duplicates");
            }
            return Created("Location", "Resource");
        }
    }
}
