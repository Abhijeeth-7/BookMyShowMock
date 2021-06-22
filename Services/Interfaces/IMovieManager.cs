using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMovieManager
    {
        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> GetMovie(int id);
    }
}
