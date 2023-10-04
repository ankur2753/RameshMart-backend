using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstraction
{
    public interface IProductRepo
    {
        public ProductWithRating GetSingleProduct(int id);
        public Task<List<ProductWithRating>> GetAllProducts();
        public  Task<List<Product>> GetPaginatedProducts(int page, int pageSize);
    }
}
