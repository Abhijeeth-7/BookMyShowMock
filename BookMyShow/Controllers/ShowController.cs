using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [ApiController]
    [Route("Movie/{movieId}/Show")]
    public class ShowController : ControllerBase
    {
        private IShowManager _showManager;
        private ITheaterManager _theaterManager;
        public ShowController(IShowManager showManager, ITheaterManager theaterManager)
        {
            _showManager = showManager;
            _theaterManager = theaterManager;
        }
        public async Task<Tuple<List<Show>,List<Theater>>> Get(int movieId)
        {
            Tuple<List<Show>, List<Theater>> result = new Tuple<List<Show>, List<Theater>>(
                await _showManager.GetShows(movieId), 
                await _theaterManager.GetTheaters()
                );
            return result;
        }

        [HttpGet("{id}")]
        public async Task<List<Seat>> GetShow(int id)
        {
            return await _showManager.GetSeatingData(id);
        }

    }
}
