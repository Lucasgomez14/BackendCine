using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketMapper
    {
        Task<TicketResponse> GenerateTicketResponse(Ticket unTicket, List<Guid> listaIds);
        Task<CantidadTicketResponse> GetCantidadTicketResponse(int cantidad, int ticketCount);
    }
}
