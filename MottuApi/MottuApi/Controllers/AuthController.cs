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
        public async Task<ActionResult<string>> Register(UserDto user)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(user);
                if (_authBusiness.Register(user))
                    return Ok("User created with success.");
                else return BadRequest();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserDto user)
        {
            string token = _authBusiness.Login(user);
            return Ok(token);
        }
    }
}
