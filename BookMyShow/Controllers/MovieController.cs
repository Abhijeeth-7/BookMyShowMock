using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {
        private IMovieManager _movieManager;
        public MovieController(IMovieManager movieManager)
        {
            _movieManager = movieManager; 
        }
        public async Task<IEnumerable<Movie>> Get()
        {
            return await _movieManager.GetMovies();
        }
        [HttpGet("{id}")]
        public async Task<Movie> GetMovie(int id)
        {
            return await _movieManager.GetMovie(id);
        }
    }
}
