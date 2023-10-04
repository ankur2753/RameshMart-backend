using BuisnessLayer.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderManager _manager;
        public OrderController(IOrderManager orderManager) {
            _manager= orderManager;
        }

        [HttpPost("placeOrder")]
        public IActionResult Get(int UserID,int PaymentMode,string TransactionID) {

            try
            {
                _manager.PlaceOrder(UserID, PaymentMode, TransactionID);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest("USER HAS NO CART");

            }

         
           
        }
    }
}
