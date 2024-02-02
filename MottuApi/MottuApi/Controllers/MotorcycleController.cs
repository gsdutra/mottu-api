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

        [HttpGet("{plate}")]
        public async Task<ActionResult<Motorcycle>> GetSingleMotorcycle(string plate)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            return Ok(_motorcycleBusiness.GetSingleMotorcyle(plate));
        }
        [HttpGet]
        public async Task<ActionResult<List<Motorcycle>>> GetAllMotorCycles()
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            return Ok(_motorcycleBusiness.GetMotorcycles());
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateMotorcycle(MotorcycleDto motorcycle)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            int newMotorcycleId = _motorcycleBusiness.CreateMotorcycle(motorcycle);
            return StatusCode(201, newMotorcycleId);
        }
        [HttpPut]
        public async Task<ActionResult<Motorcycle>> UpdateMotorcyclePlate(int id, string plate)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            return Ok(_motorcycleBusiness.UpdateMotorcycle(id, plate));
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMotorcycle(int id)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            return Ok(_motorcycleBusiness.DeleteMotorcycle(id));
        }
        [HttpGet("model")]
        public async Task<ActionResult<List<MotorcycleModel>>> GetModels()
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            return Ok(_motorcycleBusiness.GetAllModels());
        }
        [HttpPost("model")]
        public async Task<ActionResult<Motorcycle>> CreateModel(MotorcycleModelDto model)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            _motorcycleBusiness.CreateModel(model);
            return StatusCode(201);
        }
    }
}
