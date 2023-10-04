using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstraction
{
    public interface ICardRepo
    {
        public Task<List<Card>> GetCard(int UserID);
        public  Task AddNewCard(Card card);
    }

}
