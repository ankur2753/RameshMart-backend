using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstraction
{
    public interface IOrderManager
    {
        public void PlaceOrder(int UserID,  int PaymentMode, string TransactionID);
    }
}
