using Application.Interfaces;

namespace Application.Mappers
{
    public class GeneroMapper : IGeneroMapper
    {
        public async Task<Response.Genero> GetGeneroMapper(Domain.Entities.Genero unGenero)
        {
            return new Response.Genero
            {
                id = unGenero.GeneroId,
                nombre = unGenero.Nombre,
            };
        }
    }
}
