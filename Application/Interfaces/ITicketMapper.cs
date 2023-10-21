using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITicketMapper
    {
        Task<TicketResponse> GenerateTicketResponse(Ticket unTicket, List<Guid> listaIds);
        Task<CantidadTicketResponse> GetCantidadTicketResponse(int cantidad, int ticketCount);
    }
}
