using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Services;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        public readonly IWineServices _wineServices;
        public WineController(IWineServices wineServices)
        {
            _wineServices = wineServices;
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
    }
}
