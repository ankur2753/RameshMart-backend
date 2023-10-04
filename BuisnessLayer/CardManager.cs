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
    public class CardManager
    {
        CardRepo repo;
        public CardManager(IDBContext db) {
            this.repo = new(db);
        }

        public Task<List<Card>> GetCard(int id)
        {
            return repo.GetCard(id);
        }

        public async Task AddNewCard(Card card)
        {
             await repo.AddNewCard(card);
        }
    }
}
