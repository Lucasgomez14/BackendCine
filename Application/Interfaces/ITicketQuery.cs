using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITicketQuery
    {
        Task<Ticket> GetTicketById(Guid id);
    }
}
