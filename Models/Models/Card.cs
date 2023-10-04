using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Card
    {
        public Card(int iD, long cardNo, int cvv, DateTime expDate, int userID)
        {
            ID = iD;
            CardNo = cardNo;
            Cvv = cvv;
            ExpDate = expDate;
            UserID = userID;
        }

        public int ID { get; }
        public long CardNo { get; }
        public int Cvv { get; }
        public DateTime ExpDate { get; }

        public int UserID { get; }
    }
}
