using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("Movie/{id}/Show/{showId}/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IShowManager _showManager;
        private IMovieManager _movieManager;
        private ITheaterManager _theaterManager;
        private ITicketManager _ticketManager;
        public TicketController(IShowManager showManager, ITheaterManager theaterManager, ITicketManager ticketManager, IMovieManager movieManager)
        {
            _showManager = showManager;
            _theaterManager = theaterManager;
            _ticketManager = ticketManager;
            _movieManager = movieManager;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<object> Get(int showId)
        {
            Show show = await _showManager.GetShow(showId);
            
            Theater theater = await _theaterManager.GetTheater(show.TheaterId);

            string movieTitle = (await _movieManager.GetMovie(show.MovieId)).Title;
            return new {
                movieTitle = movieTitle,
                theaterName = theater.TheaterName,
                showStartTime = show.StartTime,
                showEndTime = show.EndTime,
                ticketPrice = theater.Price
                };
        }
        // POST api/<TicketController>
        [HttpPost]
        public async void Post(int showId, [FromBody] TicketInfo ticket)
        {
            await _ticketManager.GenerateTickets(ticket);
            await _showManager.UpdateSeatingData(showId, ticket.SeatIds);
        }
    }; 
}
