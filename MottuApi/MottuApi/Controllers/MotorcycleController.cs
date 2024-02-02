using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuApi.Model;
using MottuApi.Business;
using Microsoft.AspNetCore.Authorization;

namespace MottuApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly MotorcycleBusiness _motorcycleBusiness;
        private readonly AuthBusiness _authBusiness;
        public MotorcycleController(MotorcycleBusiness motorcycleBusiness, AuthBusiness authBusiness)
        {
            _motorcycleBusiness = motorcycleBusiness;
            _authBusiness = authBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<Motorcycle>> GetSingleMotorcycle()
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            return Ok(_motorcycleBusiness.GetSingleMotorcyle("test"));
        }
    }
}
