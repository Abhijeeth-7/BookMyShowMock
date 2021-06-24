using Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Services.Data
{
    public class DapperDBContext : IDBContext
    {
        private readonly IConfiguration _config;

        public DapperDBContext(IConfiguration config)
        {
            _config = config;
            
        }

        public IDbConnection Connection()
        {
            var sql = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return sql;
        }
    }
}
