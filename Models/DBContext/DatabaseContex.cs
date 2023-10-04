using System;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DBContext
{
    public class DatabaseContex : IDBContext
    {
        SqlConnection _conetext;
        public DatabaseContex(IConfiguration configuration) {
            _conetext = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IEnumerable<T>> QueryMultiple<T>(string query)
        {
            return await _conetext.QueryAsync<T>(query);
        }
        public  T  QuerySingle<T>(string query)
        {
            return  _conetext.QuerySingle<T>(query);
        }

        public async Task<int> InsertQuery(string query) {
            return await _conetext.ExecuteAsync(query);
        }
        ~DatabaseContex()
        {
            _conetext.Close();
        }
    }
}
