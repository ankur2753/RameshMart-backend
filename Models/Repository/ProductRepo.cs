using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;

namespace DataLayer.Repository
{
    public class ProductRepo:IProductRepo
    {
        IDBContext db;
        public ProductRepo(IDBContext dBContext) {
            db= dBContext;
        }

        public async Task<List<ProductWithRating>> GetAllProducts()
        {
            try
            {
                string sql = "SELECT P.*,R.RATE,R.COUNT FROM Products P,Rating R WHERE R.ProductID=P.ID ;";
                var res = await db.QueryMultiple<ProductWithRating>(sql);
                List<ProductWithRating> result = res.ToList();
                return result;
            }
            catch (Exception)
            {
                return new List<ProductWithRating>();
            }
          
        }
        public ProductWithRating GetSingleProduct(int id)
        {
            string sql = $"SELECT P.*,R.RATE,R.COUNT FROM Products P,Rating R WHERE R.ProductID=P.ID AND P.ID = {id};";
            return db.QuerySingle<ProductWithRating>(sql);
        }


        public async Task<List<Product>> GetPaginatedProducts(int page, int pageSize)
        {
            try
            {
                string sql = $"SELECT *  FROM Products P,Rating R WHERE R.ProductID=P.ID ORDER BY Price OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
                var res = await db.QueryMultiple<Product>(sql);
                return res.ToList();
            }
            catch (Exception)
            {
                return new List<Product>();   
            }
           
        }
    }
}
