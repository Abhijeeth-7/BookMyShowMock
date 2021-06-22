using Models.DataModels;
using Dapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.enums;

namespace Services.Repository
{
    public class MovieManager : IMovieManager
    {
        private IDbConnection _dbConnection;
        public MovieManager(IDBContext context)
        {
            _dbConnection = context.Connection();
        }
        public async Task<Movie> GetMovie(int id)
        {
            var parameters = new { id = id, };
            string sql = "SELECT * FROM Movie WHERE id = @id";
            Movie movie = await _dbConnection.QueryFirstAsync<Movie>(sql, parameters);
            movie.Genre = ((Genre)Convert.ToInt32(movie.Genre)).ToString();
            return movie;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            string sql = "SELECT * FROM Movie";
            var movies = await _dbConnection.QueryAsync<Movie>(sql);
            return movies.ToList();
        }
    }
}
