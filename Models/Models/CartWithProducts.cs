using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class CartWithProducts : Cart
    {
        public List<ProductWithQuantity> products { get; }
        public CartWithProducts(int ID, int UserID, bool isActive, List<ProductWithQuantity> products) : base(ID, UserID, isActive)
        {
            this.products = products;
        }

    }

   

}
