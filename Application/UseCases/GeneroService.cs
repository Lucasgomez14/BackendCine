using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroQuery _query;
        public GeneroService(IGeneroQuery generoQuery)
        {
            _query = generoQuery;
        }
        public async Task<List<Genero>> AllGeneros()
        {
            try
            {
                return await _query.GetAllGeneros();
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error: " + ex.Message);
            }
        }
    }
}
