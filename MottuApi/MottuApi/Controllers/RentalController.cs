using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuApi.Business;
using MottuApi.Model;
using MottuApi.Repository;

namespace MottuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly RentalBusiness _rentalBusiness;
        private readonly AuthBusiness _authBusiness;
        public RentalController(RentalBusiness rentalBusiness, AuthBusiness authBusiness)
        {
            _rentalBusiness = rentalBusiness;
            _authBusiness = authBusiness;
        }
        [HttpGet("plans")]
        public async Task<ActionResult<List<Motorcycle>>> GetAllPlans()
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            return Ok(_rentalBusiness.ConsultPlans());
        }
        [HttpPost("simulate")]
        public async Task<ActionResult<List<Motorcycle>>> Simulate(RentalDto rental)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            return Ok(_rentalBusiness.GetSimulationValue(rental));
        }
    }
}
