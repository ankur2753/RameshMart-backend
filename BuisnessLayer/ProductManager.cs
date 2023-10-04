using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ProductManager:IProductManager
    {
        IProductRepo repo;
        public ProductManager(IProductRepo productRepo) {
            repo= productRepo;
        }

        public async Task<List<ProductWithRating>> GetAllProducts() {
            return await repo.GetAllProducts();
        }

        public  ProductWithRating GetSingleProduct(int id) {
            return repo.GetSingleProduct(id);
        }

        public async Task<List<Product>> GetPaginatedProduct(int page,int limit) { 
            return await repo.GetPaginatedProducts(page, limit);
        }
    }
}
