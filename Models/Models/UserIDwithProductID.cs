using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserIDwithProductID
    {
        public UserIDwithProductID(int UserId, int ProductId)
        {
            UserID = UserId;
            ProductID = ProductId;
        }
        public int UserID { get; }
        public int ProductID { get; }
    }
}
