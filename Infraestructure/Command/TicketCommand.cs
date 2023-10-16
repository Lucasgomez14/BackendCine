using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly CineBD _context;

        public TicketCommand(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<Guid> RegisterTicket(Ticket ticket)
        {
            try
            {
                _context.Add(ticket);
                _context.SaveChanges();
                return ticket.TicketId;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema en añadir el ticket");
            }
        }
    }
}
