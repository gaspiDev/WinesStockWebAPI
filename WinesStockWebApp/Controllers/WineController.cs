using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Services;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
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
                int newWineId = _wineServices.AddWine(wineDTO);
                return Ok($"The Wine Id: {newWineId} has created succesfully.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"A wine with the name {wineDTO.Name.ToUpper()} already exists and can't store duplicates.");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("WineStock")]
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineServices.GetAllWinesStock());
        }
    }
}
