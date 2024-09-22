using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Common.Models;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineStockController : ControllerBase
    {
        public readonly WineServices _wineServices;
        public readonly UserServices _userServices;
        public WineStockController(WineServices wineServices, UserServices userServices)
        {
            _wineServices = wineServices;
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Wine")]
        public IActionResult AddWine([FromBody] CreateWineDTO wineDTO)
        {
            if (wineDTO == null)
            {
                return BadRequest("The request's body is null.");
            }
            try
            {
                _wineServices.AddWine(wineDTO);
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"A wine with the name {wineDTO.Name.ToUpper()} already exists and can't store duplicates");
            }
            return Created("Location", "Resource");
        }

        [HttpGet]
        [Route("WineStock")]
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineServices.GetAllWinesStock());
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
