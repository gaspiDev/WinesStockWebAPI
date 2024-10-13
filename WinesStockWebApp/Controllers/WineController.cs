using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using Common.Enums;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        public readonly IWineServices _wineServices;
        public WineController(IWineServices wineServices)
        {
            _wineServices = wineServices;
        }

        [HttpPost]
        public IActionResult CreateWine([FromBody] NewWineDto wineDTO)
        {
            try
            {
                int newWineId = _wineServices.CreateWine(wineDTO);
                return Ok($"The Wine Id: {newWineId} has created succesfully.");
            }
            catch (Exception)
            {
                return BadRequest($"A wine with the name {wineDTO.Name.ToUpper()} already exists and can't store duplicates.");
            }
        }

        [HttpGet]
        public IActionResult ReadWine()
        {
            try
            {
                return Ok(_wineServices.ReadWine());
            }
            catch (Exception)
            {
                return NotFound("Can't get access to wines information.");
            }
        }

        [HttpGet]
        [Route("variety/{variety}")]
        public IActionResult ReadWineByVariety(Variety variety) 
        {
            try
            {
                return Ok(_wineServices.ReadWineByVariety(variety));
            }
            catch (Exception)
            {
                return NotFound("Can't get access to wines information.");
            }

        }

        [HttpPut]
        [Route("{id}/stock")]
        public IActionResult UpdateWinestockById(int id,[FromBody] int stock) 
        {
            if (stock > 0)
            {
                try
                {
                    _wineServices.UpdateWinestockById(id, stock);
                    return Ok($"Wine Id: {id}, now has {stock} bottles of stock.");
                }
                catch (Exception)
                {
                    return BadRequest("The wine Id or Stock isn't valid.");
                }
            }
            else 
            {
             return BadRequest("The input stock must be greater than 0.");
            }
        }

    }
}
