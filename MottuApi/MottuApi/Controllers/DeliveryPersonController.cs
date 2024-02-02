using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuApi.Business;
using MottuApi.Model;

namespace MottuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPersonController : ControllerBase
    {
        private readonly DeliveryPersonBusiness _deliveryPersonBusiness;
        private readonly AuthBusiness _authBusiness;
        public DeliveryPersonController(DeliveryPersonBusiness deliveryPersonBusiness, AuthBusiness authBusiness)
        {
            _deliveryPersonBusiness = deliveryPersonBusiness;
            _authBusiness = authBusiness;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> AddDeliveryPersonData(DeliveryPerson deliveryPeron)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            if (!userData.IsAdmin) return Unauthorized();
            if (deliveryPeron.UserId != userData.Id) return Unauthorized();
            _deliveryPersonBusiness.AddData(deliveryPeron);
            return StatusCode(201, "Added data");
        }
    }
}
