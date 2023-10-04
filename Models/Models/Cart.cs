using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Cart
    {
        public Cart(int ID,int UserID,bool isActive) { 
            this.ID = ID;
            this.UserID = UserID;
            this.IsActive = IsActive;
        }
        public int ID { get; }
        public int UserID { get; }
        public bool IsActive { get; }

    }
}
