using Models.DataModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITicketManager
    {
        public Task GenerateTicket(Ticket Ticket);
        public Task GenerateTickets(TicketInfo TicketInfo);
        //public Task<List<Movie>> GetTickets();
        //public Task<List<Ticket>> GetValidTickets();
        //public Task<List<Ticket>> GetExpiredTickets();
        //public Task<bool> ValidateTicket(int id);

    }
}
