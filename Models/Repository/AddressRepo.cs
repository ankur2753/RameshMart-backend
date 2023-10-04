using DataLayer.DBContext;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class AddressRepo
    {
        IDBContext db;
        public AddressRepo(IDBContext db)
        {
            this.db = db;
        }

        public async Task<List<Address>> GetAddress(int UserID) {
            try
            {
                string sql = $"SELECT * FROM Address WHERE UserID ={UserID}";
                var list = await db.QueryMultiple<Address>(sql);
                return list.ToList();
            }
            catch (Exception)
            {
               return new List<Address> ();
            }
          
        }


        public async Task AddNewAddress (Address address)
        {
            string sql = $"INSERT INTO Address(City,Street,State,UserID) Values('{address.City}','{address.Street}','{address.State}',{address.UserID});";
           await db.InsertQuery(sql);
        }

        public async Task DeleteAddress(int UserID,int AddressID)
        {
            string sql = $"DELETE FROM Address WHERE UserID={UserID} AND ID={AddressID} ";
            await db.InsertQuery(sql);
        }


        public async Task UpdateAddress(Address address)
        {
            string sql = $"UPDATE ADDRESS SET City='{address.City}',Street='{address.Street}',State='{address.State}'WHERE ID={address.ID} ";
            await db.InsertQuery(sql);

        }
    }
}
