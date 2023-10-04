using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class AddressManager
    {
        AddressRepo repo;
        public AddressManager(IDBContext dBContext) {
            repo= new AddressRepo(dBContext);
        }

        public async Task<List<Address>> GetAddresses(int UserID) {
            return await repo.GetAddress(UserID);
        }

        public async Task DeleteAddress(int UserID,int AddressID) {
             await repo.DeleteAddress(UserID,AddressID);
        }

        public async Task AddAddress(Address address) {
            await repo.AddNewAddress(address);
        }

        public async Task UpdateAddress(Address address) {
            await repo.UpdateAddress(address);
        }
    }
}
