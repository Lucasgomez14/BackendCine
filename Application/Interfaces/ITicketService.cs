using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface ITicketService
    {
        public Task<TicketResponse> createTicket(int funcionId, TicketRequest ticketRequest);
    }
}
