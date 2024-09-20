﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Common;

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
                return BadRequest();
            }
            try
            {
                _wineServices.AddWine(wineDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Created();
        }

        [HttpGet]
        public IActionResult WinesStock()
        {
            return Ok(_wineServices.WinesStock());
        }

        [HttpPost]
        [Route("User")]
        public IActionResult AddUser([FromBody] CreateUserDTO userDTO)
        {
            _userServices.AddUser(userDTO);
            return Created();
        }
    }
}