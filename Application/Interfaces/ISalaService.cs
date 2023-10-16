using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISalaService
    {
        public Task<bool> ExistSala(int salaId);
        public Task<Sala> GetSalaById(int salaId);
    }
}
