using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] NewUserDto userDto)
        {
            try
            {
                int newUserId = _userServices.CreateUser(userDto);
                return Ok($"The User Id: {newUserId} has created succesfully.");
            }
            catch (Exception)
            {
                return BadRequest($"A user with the username {userDto.Username.ToUpper()} already exists and can't store duplicates");
            }
        }
    }
}
