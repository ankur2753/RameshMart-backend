using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{

    public class UserNamePass
    {
        public UserNamePass(string UserName,string PassWord)
        {
            this.UserName = UserName;
            this.Password= PassWord;
        }
        public string UserName { get;  }
        public string Password { get;  }
    }
    public class Auth:UserNamePass
    {
        public Auth(int ID,string UserName,string Password):base(UserName,Password) {
            this.ID= ID;
        }
        public int ID { get; set; }
       
    }
}
