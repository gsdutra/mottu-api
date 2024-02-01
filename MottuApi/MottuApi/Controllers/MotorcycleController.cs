using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuApi.Model;
using MottuApi.Business;
using Microsoft.AspNetCore.Authorization;

namespace MottuApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MotorcycleController : ControllerBase
    {
        private readonly MotorcycleBusiness _motorcycleBusiness;
        public MotorcycleController(MotorcycleBusiness motorcycleBusiness)
        {
            _motorcycleBusiness = motorcycleBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<Motorcycle>> GetSingleMotorcycle()
        {
            return Ok(_motorcycleBusiness.GetSingleMotorcyle("test"));
        }
    }
}
