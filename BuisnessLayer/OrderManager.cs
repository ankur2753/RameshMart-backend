using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public  class OrderManager:IOrderManager
    {
       IOrderRepo repo;
        public OrderManager(IOrderRepo orderRepo)
        {
            this.repo= orderRepo;
        }

        public void PlaceOrder(int UserID,int PaymentMode,string TransactionID) {
            string payMode = "COD";
            switch (PaymentMode)
            {
                case 0: payMode = "COD";
                    break;
                case 1: payMode = "UPI";
                    break;
                case 2: payMode = "CRD";
                    break;
                default:
                    break;
            }
             repo.PlaceOrder(UserID, payMode, TransactionID);
        }
    }
}
