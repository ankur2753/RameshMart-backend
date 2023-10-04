using BuisnessLayer.Abstraction;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductManager manager;
        public ProductController(IProductManager productManager)
        {
                manager= productManager;
        }

        // GET: api/<ProductController>
        [HttpGet("all")]
        public async Task<ActionResult<ProductWithRating>> AllProducts()
        {
            try
            {

                List<ProductWithRating> res=  await manager.GetAllProducts();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public  ActionResult<ProductWithRating> SingleProduct(int id)
        {
            try
            {
               ProductWithRating res= manager.GetSingleProduct(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{page}&{limit}")]
        public async Task<ActionResult<List<Product>>> GetPaginatedResult(int page,int limit)
        {
            try
            {
              List<Product> res= await manager.GetPaginatedProduct(page, limit);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
