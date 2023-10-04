using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstraction
{
    public  interface IProductManager
    {
        public Task<List<ProductWithRating>> GetAllProducts();
        public ProductWithRating GetSingleProduct(int id);
        public  Task<List<Product>> GetPaginatedProduct(int page, int limit);
    }   
}
