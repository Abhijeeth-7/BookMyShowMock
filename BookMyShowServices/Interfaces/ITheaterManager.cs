using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITheaterManager
    {
        public Task<List<Theater>> GetTheaters();
        public Task<Theater> GetTheater(int id);
    }
}
