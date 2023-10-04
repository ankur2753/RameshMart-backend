using DataLayer.DBContext;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class OrdersRepo:IOrderRepo
    {
        IDBContext db;
        public OrdersRepo(IDBContext dBContext) {
            this.db = dBContext;
        }

        public void PlaceOrder(int UserID,string PaymentMode,string TransactionID) {
            string sql = $"EXEC dbo.PLACEORDER @UserID={UserID},@PaymentMode='{PaymentMode}',@Transaction='{TransactionID}'";
            db.InsertQuery(sql) ;
        }

      
    }
}
