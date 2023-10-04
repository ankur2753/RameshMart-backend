using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;

namespace DataLayer.Repository
{
    public class AuthRepository:IAuthRepo
    {
        IDBContext _dBContext;
        public AuthRepository(IDBContext dBContext) {
            _dBContext = dBContext;
        }
        public async Task<List<string>> GetAllUserNames() {
           var list= await _dBContext.QueryMultiple<Auth>("select * from UserAuth;");
            list.ToList();
            List<string> res =new();
            foreach (var item in list)
            {
                res.Add(item.UserName);
            }
            return res;
        }

        public Auth GetPassWord(string userName)
        {
            var list =  _dBContext.QuerySingle<Auth>($"select * from UserAuth WHERE UserName='{userName}'");
            return list;
        }

        public  async Task<bool> AddNewUser(string username,string password)
        {
            string sql = $"INSERT INTO UserAuth(UserName,Password) values('{username}','{password}');";
            return await _dBContext.InsertQuery(sql) ==1;
        }
    }
}
