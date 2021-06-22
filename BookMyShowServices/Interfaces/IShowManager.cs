using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IShowManager
    {
        public Task<Show> GetShow(int showId);
        public Task<List<Show>> GetShows();
        public Task<List<Seat>> GetSeatingData(int showid);
        public Task<string> UpdateSeatingData(int Id, dynamic seatingString);
        //public Task CreateShow(int movieId, int ScreenId);
        //public Task<List<Show>> GetValidShows();
        //public Task<List<Show>> GetShowsInPLay();
        //public Task<List<Show>> GetExpiredShows();
        //public Task SetShowTime(int movieId, TimeSpan duration);
    }
}
