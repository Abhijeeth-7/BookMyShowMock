using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public class Seating
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public int TheaterId { get; set; }
        public String SeatingData { get; set; }
    }
}
