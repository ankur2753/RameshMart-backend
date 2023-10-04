using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstraction
{
    public interface IAuthManager
    {
        public int Login(UserNamePass user);
        public Task<bool> AddNewUser(UserNamePass user);

        public Task<List<string>> getAllUsers();
    }
}
