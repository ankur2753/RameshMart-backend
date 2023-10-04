using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstraction
{
    public interface ICartManager
    {
        public  Task AddToCart(int UserID, int ProductID);
        public  Task IncreaseQunatity(int UserID, int ProductID);
        public Task DecreaseQunatity(int UserID, int ProductID);
        public void RemoveFromCart(int UserID, int ProductID);
        public Cart GetCart(int id);
        public  Task<CartWithProducts> GetCartWithProducts(int id);
    }
}
