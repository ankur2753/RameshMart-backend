using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class AuthManager:IAuthManager
    {
        IAuthRepo authRepository;
        public AuthManager(IAuthRepo repo)
        {
            authRepository = repo;
        }
        public  int Login(UserNamePass user)
        {
            Auth auth = authRepository.GetPassWord(user.UserName);
            if (auth.Password.Equals(user.Password)) return auth.ID;
            return -1;
        }
        

        public async Task<List<string>> getAllUsers() {
            return await authRepository.GetAllUserNames();
        }

        public  async Task<bool> AddNewUser(UserNamePass user)
        {
            return  await authRepository.AddNewUser(user.UserName,user.Password);
        }

    }
}
