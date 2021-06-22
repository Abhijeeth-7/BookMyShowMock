using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public class Theater
    {
        public int Id { get; set; }
        public string TheaterName { get; set; }
        public int TotalSeats { get; set; }
        public int Price { get; set; }
    }
}
