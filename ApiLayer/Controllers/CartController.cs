using BuisnessLayer.Abstraction;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartManager  _cartManager;
        public CartController(ICartManager cart) {
            _cartManager= cart;
        }

      

        // GET api/<CartController>/5
        [HttpGet("{Userid}")]
        public async Task<ActionResult<CartWithProducts>> CartProducts(int Userid)
        {
            try
            {
                var res =await _cartManager.GetCartWithProducts(Userid);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart([FromBody]UserIDwithProductID IDs) {
            try
            {
                await _cartManager.AddToCart(IDs.UserID, IDs.ProductID);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
         
        }


        // POST api/<CartController>
        [HttpPut("decrement")]
        public IActionResult Decrease(UserIDwithProductID IDs)
        {
            try
            {
                _cartManager.DecreaseQunatity(IDs.UserID,IDs.ProductID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        // PUT api/<CartController>/5
        [HttpPut("increment")]
        public ActionResult Increase(UserIDwithProductID IDs )
        {
            try
            {
                _cartManager.IncreaseQunatity(IDs.UserID,IDs.ProductID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE api/<CartController>/5
        [HttpDelete("delete")]
        public IActionResult Delete(UserIDwithProductID IDs)
        {
            try
            {
                _cartManager.RemoveFromCart(IDs.UserID,IDs.ProductID);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
