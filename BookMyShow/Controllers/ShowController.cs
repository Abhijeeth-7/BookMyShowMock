using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("Movie/{movieId}/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private IShowManager _showManager;
        private ITheaterManager _theaterManager;
        public ShowController(IShowManager showManager, ITheaterManager theaterManager)
        {
            _showManager = showManager;
            _theaterManager = theaterManager;
        }
        // GET: api/<ShowController>
        [HttpGet]
        public async Task<List<dynamic>> Get()
        {
            List<dynamic> result = new List<dynamic>();
            result.Add(await _showManager.GetShows());
            result.Add(await _theaterManager.GetTheaters());
            return result;
        }

        // GET api/<ShowController>/5
        [HttpGet("{id}")]
        public async Task<List<Seat>> Get(int id)
        {
            return await _showManager.GetSeatingData(id);
        }

    }
}
