using BuisnessLayer;
using DataLayer.DBContext;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        readonly AddressManager _addressManager;
        public AddressController(IDBContext dBContext)
        {
            _addressManager = new AddressManager(dBContext);
        }
        // GET api/<AddressController>/5
        [HttpGet("{UserID}")]
        public async Task<ActionResult<List<Address>>> Get(int UserID)
        {
            try
            {
                List<Address> addresses = await _addressManager.GetAddresses(UserID);
                return Ok(addresses);
            }
            catch (Exception)
            {

                return BadRequest();
            }
         
        }

        // POST api/<AddressController>
        [HttpPost]
        public async void Post([FromBody] Address address)
        {
            await _addressManager.AddAddress(address);
        }

        // PUT api/<AddressController>/5
        [HttpPut()]
        public async void Put([FromBody] Address address)
        {
            await _addressManager.UpdateAddress(address);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete()]
        public async Task<ActionResult> Delete(int UserID,int AddressID)
        {
            await _addressManager.DeleteAddress(UserID, AddressID);
            return Ok();
        }
    }
}
