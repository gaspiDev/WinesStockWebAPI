using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common;
using Common.Models;
using Services;
using Data.Entities;

namespace WinesStockWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public AuthenticationController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsDTO credentialsDTO)
        {
            User? user = _userServices.ValidateUser(credentialsDTO);
            if (user == null)
            {
                return Unauthorized();
            }
            //add all logic for returning the JWT
            return Ok();
        }
    }
}
