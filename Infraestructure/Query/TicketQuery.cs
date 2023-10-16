using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineBD _context;

        public TicketQuery(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<Ticket> GetTicketById(Guid id)
        {
            try
            {
                return await _context.Tickets
                    .Include(t => t.Funcion)
                    .Include(t => t.Funcion.Sala)
                    .Include(t => t.Funcion.Pelicula)
                    .Include(t => t.Funcion.Pelicula.Genero)
                    .SingleOrDefaultAsync(t => t.TicketId.Equals(id));
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("Error en la base de datos: Problema con el ticket");
            }
        }
    }
}
