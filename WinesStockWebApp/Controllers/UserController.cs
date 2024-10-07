using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
        [Authorize]
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
                int newUserId = _userServices.AddUser(userDTO);
                return Ok($"The User Id: {newUserId} has created succesfully.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"A user with the username {userDTO.Username.ToUpper()} already exists and can't store duplicates");
            }
        }
    }
}
