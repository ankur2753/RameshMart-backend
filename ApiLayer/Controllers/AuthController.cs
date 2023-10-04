using BuisnessLayer;
using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace ApiLayer.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthManager authManager;
        public AuthController(IAuthManager manager)
        {
            authManager = manager;
        }

        // GET: api/<AuthController>
        [HttpGet("allUsers")]
        public async Task<ActionResult<List<string>>> Get()
        {
            try
            {
                var res = await authManager.getAllUsers();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
         
        }


        // POST api/<AuthController>
        [HttpPost("/login")]
        public ActionResult<int> Login( UserNamePass user)
        {
            try
            {
                int res = authManager.Login(user);
                if (res == -1)return Unauthorized("incorrect ");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed "+ex.Message);
            }
           
        }
        [HttpPost("/register")]
        public async Task<ActionResult<bool>> Register( UserNamePass user)
        {
            try
            {
                bool isDone = await authManager.AddNewUser(user);
                return Ok(isDone);
            }
            catch (Exception ex)
            {
                return BadRequest("unsuccesful \n"+ex.Message);
            }
          
        }

       
    }
}
