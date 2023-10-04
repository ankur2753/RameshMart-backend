using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstraction
{
    public interface ICartRepo
    {
        public Task AddToCart(int UserID,int ProductID);
        public Task AlterQuantity(int UserID,int ProductID,int Quantity);
        public Task<int> GetQuantity(int ProductID, int UserID);
        public void DeleteProduct(int UserID, int ProductID);
        public Cart GetCart(int uid);
        public Task<List<ProductWithQuantity>> GetProduct(int uid);
    }
}
