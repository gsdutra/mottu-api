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
        public async Task<ActionResult<bool>> AddDeliveryPersonData(DeliveryPersonDto deliveryPeron)
        {
            User userData = _authBusiness.Authenticate(HttpContext.Request.Headers["Authorization"]);
            try
            {
                _deliveryPersonBusiness.AddData(deliveryPeron, userData.Id);
                return StatusCode(201, "Added data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
