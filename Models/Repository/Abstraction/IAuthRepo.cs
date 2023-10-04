using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstraction
{
    public interface IAuthRepo
    {
        public Auth GetPassWord(string userName);
        public  Task<bool> AddNewUser(string username, string password);
        public Task<List<string>> GetAllUserNames();
    }
}
