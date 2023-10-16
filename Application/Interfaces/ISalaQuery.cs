using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISalaQuery
    {
        public Task<Sala> GetSalaById(int salaId);
    }
}
