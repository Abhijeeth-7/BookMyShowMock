using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class TicketInfo
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public List<string> SeatIds { get; set; }
        public int Price { get; set; }
    }
}
