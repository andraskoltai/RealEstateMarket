using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateMarket.Api.DTOs;

namespace RealEstateMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // todo
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO register)
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            return Ok();
        }
    }
}
