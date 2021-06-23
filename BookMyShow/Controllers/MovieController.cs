using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieManager _movieManager;
        public MovieController(IMovieManager movieManager)
        {
            _movieManager = movieManager; 
        }
        [HttpGet]
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
