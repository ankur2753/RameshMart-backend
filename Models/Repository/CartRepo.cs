using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class CartRepo:ICartRepo
    {
        private readonly IDBContext db;
        public CartRepo(IDBContext dBContext) { 
            this.db = dBContext;
        }

        public async Task AddToCart(int UserID, int ProductID)
        {
            string sql = $"EXEC dbo.ADDTOCART @UserID={UserID},@ProductID={ProductID}";
            await db.InsertQuery(sql);
        }

        public async Task AlterQuantity(int UserID, int ProductID, int Quantity)
        {
            string sql = $"EXEC dbo.ALTERQUANTITY @UserID={UserID},@ProductID={ProductID}, @Quantity={Quantity};";
            await db.InsertQuery(sql);
        }

        public async Task<int> GetQuantity(int UserID,int ProductID) {
            string sql = $"SELECT Quantity FROM CartProducts WHERE ID IN (SELECT ID FROM Carts WHERE UserID={UserID}) AND ProductID={ProductID}";
            var res= await db.QueryMultiple<int>(sql);
            if (res.Count() < 1) return 0;
            return res.First();
        }

        public void DeleteProduct(int UserID,int ProductID) {
            string sql = $"EXEC dbo.REMOVEFROMCART @UserID={UserID}, @ProductID={ProductID}";
            db.InsertQuery(sql);
        }
        public Cart GetCart(int uid) {
            string sql = $"SELECT * FROM Carts WHERE UserID={uid}AND IsActive =1";
            return db.QuerySingle<Cart>(sql);
        }

        public async Task<List<ProductWithQuantity>> GetProduct(int uid)
        {
            try
            {
                string sql = $"EXEC dbo.GETCARTPRODUCTS @UserID={uid};";

                var res = await db.QueryMultiple<ProductWithQuantity>(sql);
                return res.ToList();
            }
            catch (Exception)
            {

                return new List<ProductWithQuantity>();
            }
           
        }

    }
}
