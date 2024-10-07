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
    public class WineController : ControllerBase
    {
        public readonly IWineServices _wineServices;
        public WineController(IWineServices wineServices)
        {
            _wineServices = wineServices;
        }

        [Authorize]
        [HttpPost]
        [Route("NewWine")]
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
        [Route("WineStockAll")]
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineServices.GetAllWinesStock());
        }

        [Authorize]
        [HttpGet]
        [Route("WineStockByVariety")]
        public IActionResult GetByVarietyWineStock(Variety variety) 
        {
            return Ok(_wineServices.GetByVarietyWinesStock(variety));
        }

        [Authorize]
        [HttpPut]
        [Route("ModifyWineStockByVariety")]
        public IActionResult ModifyWineStockByVariety([FromBody] ModifyByIdWineStock newWineStock) 
        {
            return Ok($"Wine Id: {_wineServices.ModifyWineStockByVariety(newWineStock).Id}, now has {_wineServices.ModifyWineStockByVariety(newWineStock).Stock} bottles of stock.");   
        }

    }
}
