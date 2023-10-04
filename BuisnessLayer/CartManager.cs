using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class CartManager:ICartManager
    {
        ICartRepo repo;
        public CartManager(ICartRepo cartRepo) {
            repo = cartRepo;
        }

        public Cart GetCart(int id)
        {
            return repo.GetCart(id);
        }

        public async Task<CartWithProducts> GetCartWithProducts(int id) {
            Cart res = repo.GetCart(id);
            List<ProductWithQuantity> products= await repo.GetProduct(id);
            return new CartWithProducts(res.ID,res.UserID,res.IsActive,products);
        }
        public async Task AddToCart(int UserID,int ProductID) {
           await repo.AddToCart(UserID, ProductID); 
        }

        public async Task IncreaseQunatity(int UserID,int ProductID)
        {
            int Quantity = await repo.GetQuantity(UserID, ProductID);
            Quantity++;
            await repo.AlterQuantity(UserID, ProductID,Quantity);
        }
        public async Task DecreaseQunatity(int UserID, int ProductID)
        {
            int Quantity = await repo.GetQuantity(UserID, ProductID);
            if (Quantity < 2) return;
            Quantity--;
            await repo.AlterQuantity(UserID, ProductID, Quantity);
        }

        public  void RemoveFromCart(int UserID,int ProductID) {
            repo.DeleteProduct(UserID,ProductID);
        }

    }
}
