using BuisnessLayer;
using DataLayer.DBContext;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("card/[controller]")]
    [ApiController]
    public class CardController:ControllerBase
    {
        readonly CardManager cardManager;
        public CardController(IDBContext dBContext)
        {
            cardManager= new CardManager(dBContext);
        }
        [HttpGet]
        public async Task<IActionResult> Card(int UserID) {
            List<Card>res= await cardManager.GetCard(UserID);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> AddCard(Card card) {
            try
            {
               await cardManager.AddNewCard(card);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }

       
    }
}
