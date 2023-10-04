using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBContext
{
    public interface IDBContext
    {
        public Task<IEnumerable<T>> QueryMultiple<T>(string query);
        public T QuerySingle<T>(string query);

        public Task<int> InsertQuery(string query);

    }
}
