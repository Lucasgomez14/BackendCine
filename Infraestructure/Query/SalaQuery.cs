using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Query
{
    public class SalaQuery : ISalaQuery
    {
        private readonly CineBD _context;

        public SalaQuery(CineBD DBContext)
        {
            this._context = DBContext;
        }
        public async Task<Sala> GetSalaById(int salaId)
        {
            return _context.Salas.SingleOrDefault(s => s.SalaId.Equals(salaId));
        }
    }
}
