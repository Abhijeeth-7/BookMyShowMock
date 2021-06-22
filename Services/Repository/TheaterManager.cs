using Models.DataModels;
using Dapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class TheaterManager : ITheaterManager
    {
        private IDbConnection _dbConnection;
        public TheaterManager(IDBContext context)
        {
            _dbConnection = context.Connection();
        }
        public async Task<List<Theater>> GetTheaters()
        {
            string sql = "SELECT * FROM Theater";
            var theaters = await _dbConnection.QueryAsync<Theater>(sql);
            return theaters.ToList();
        }
        public async Task<Theater> GetTheater(int id)
        {
            string sql = "SELECT * FROM Theater where id = @id";
            var param = new { id = id};
            Theater theater = await _dbConnection.QueryFirstOrDefaultAsync<Theater>(sql,param);
            Console.WriteLine(theater.TheaterName);
            return theater;
        }
    }
}
