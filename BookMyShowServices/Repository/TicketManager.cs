using Models.DataModels;
using Dapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class TicketManager: ITicketManager
    {
        private IDbConnection _dbConnection;
        public TicketManager(IDBContext context)
        {
            _dbConnection = context.Connection();
        }

        public async Task GenerateTicket(Ticket ticket)
        {
            string sql = "INSERT INTO Ticket VALUES(@Id, @ShowId, @SeatId, @Price)";
            var param = new { 
                Id = ticket.Id, 
                ShowId = ticket.ShowId, 
                SeatId = ticket.SeatId, 
                Price = ticket.Price 
            };
            await _dbConnection.ExecuteAsync(sql, param);
        }
        public async Task GenerateTickets(dynamic TicketInfo)
        {
            string sql = "SELECT Id FROM Ticket ORDER BY Id DESC";
            var ticketId = (await _dbConnection.QueryAsync<int>(sql)).FirstOrDefault();

            Ticket ticket = new Ticket();
            ticket.Id = ticketId != null ? Convert.ToInt32(ticketId) + 1 : 1;
            ticket.Price = TicketInfo.Price;
            ticket.ShowId = TicketInfo.ShowId;
            foreach(string seatId in TicketInfo.SeatIds)
            {
                ticket.SeatId = seatId;
                await GenerateTicket(ticket);
                ticket.Id += 1;
            }
        }
    }
}
