using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Address
    {
        public string City { get; set; }
        public string? Street { get; set; }
        public string? State { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }

        public Address(String City,string? Street,string? State,int ID,int UserID) {
            this.City = City;
            this.Street = Street;
            this.State = State;
            this.UserID = UserID;
            this.ID= ID;
        }

    }
}
