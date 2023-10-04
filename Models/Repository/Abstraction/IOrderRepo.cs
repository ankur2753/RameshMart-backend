using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstraction
{
    public interface IOrderRepo
    {
        public void PlaceOrder(int UserID, string PaymentMode, string TransactionID);
    }
}
