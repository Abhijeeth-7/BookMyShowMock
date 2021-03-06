using Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;
using Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [ApiController]
    [Route("api/Movie/{movieId}/Show/{showId}/Ticket")]
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
        [HttpGet]
        public async Task<OrderSummary> GetOrderSummary(int showId)
        {
            Show show = await _showManager.GetShow(showId);
            
            Theater theater = await _theaterManager.GetTheater(show.TheaterId);

            string movieTitle = (await _movieManager.GetMovie(show.MovieId)).Title;
            return new OrderSummary{
                    movieTitle = movieTitle,
                    theaterName = theater.TheaterName,
                    showStartTime = show.StartTime,
                    showEndTime = show.EndTime,
                    ticketPrice = theater.Price
                };
        }
        public async void PostTicket(int showId, TicketInfo ticket)
        {
            if(await _showManager.UpdateSeatingData(showId, ticket.SeatIds))
            {
                await _ticketManager.GenerateTickets(ticket);
            }
        }
    }; 
}
