using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    class TicketInfo
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Array SeatIds { get; set; }
        public int Price { get; set; }
    }
}
