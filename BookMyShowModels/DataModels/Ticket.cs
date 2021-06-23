using System;
using System.Collections.Generic;

namespace Models.DataModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ShowId {get; set;}
        public string SeatId { get; set; }
        public int Price { get; set; }
    }
}
