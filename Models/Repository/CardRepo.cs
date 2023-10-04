using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class CardRepo:ICardRepo
    {
        IDBContext dbContext;
        public CardRepo(IDBContext dB) { 
            this.dbContext = dB;
        }


        public async Task<List<Card>> GetCard(int UserID) {
            try
            {
                IEnumerable<Card> res = await dbContext.QueryMultiple<Card>($"SELECT * FROM CardDetails WHERE UserID = {UserID};");
                return res.ToList();
            }
            catch (Exception)
            {

                return new List<Card>();    
            }
         
        }


        public async Task AddNewCard(Card card) {
        
                string sql = $"INSERT INTO CardDetails(CardNo,CVV,ExpDate,UserID) VALUES({card.CardNo},{card.Cvv},'{card.ExpDate}',{card.UserID})";
                await dbContext.InsertQuery(sql);
         
        }
    }
}
