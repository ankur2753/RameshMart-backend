namespace DataLayer.Models
{
    
    public  class Product
    {

       
        public Product(int ID, int Price,string Title,string Description,string Category,string Image)
        {
            this.ID = ID;
            this.Price = Price;
            this.Title = Title;
            this.Description = Description;
            this.Category = Category;
            this.Image= Image;

        }
        public int ID { get; set; }
        public int Price { get; set; } 
        public string Title { get; set; }
        public string Description { get;set; }
        public string Category { get;set; }
        public string Image { get;set; }

    }
    public class ProductWithQuantity : Product
    {
        public int quantity { get; }
        public ProductWithQuantity(int ID, int Price, string Title, string Description, string Category, string Image, int quantity) : base(ID, Price, Title, Description, Category, Image)
        {
            this.quantity = quantity;
        }
    }

    public class ProductWithRating : Product
    {
        public class Rating
        {
            public Rating(double rate, double count)
            {
                Rate = rate;
                Count = count;
            }

            public double Rate { get; }
            public double Count { get; }
        }
        public Rating rating { get; set; }
        public ProductWithRating(int ID, int Price, string Title, string Description, string Category, string Image,double RATE,double Count) : base(ID, Price, Title, Description, Category, Image)
        {

            this.rating = new(RATE,Count);
        }
    }
}
