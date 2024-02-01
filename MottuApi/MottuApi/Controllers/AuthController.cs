using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuApi.Business;
using MottuApi.Model;

namespace MottuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthBusiness _authBusiness;

        public AuthController(AuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto user)
        {
            ArgumentNullException.ThrowIfNull(user);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserDto user)
        {
            string token = _authBusiness.Login(user);
            return Ok(token);
        }
    }
}
