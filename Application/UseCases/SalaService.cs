using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class SalaService : ISalaService
    {
        private readonly ISalaQuery _query;

        public SalaService(ISalaQuery salaQuery)
        {
            _query = salaQuery;
        }
        public async Task<bool> ExistSala(int salaId)
        {
            return await GetSalaById(salaId) == null;
        }
        public async Task<Sala> GetSalaById(int salaId)
        {
            return await _query.GetSalaById(salaId);
        }
    }
}
