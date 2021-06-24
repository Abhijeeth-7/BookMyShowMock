using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public class Show
    {
        public int Id { get; set; }
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int SeatingId { get; set; }
    }
}
