using Application.Interfaces;
using Domain.Entities;

namespace Application.Mappers
{
    public class SalaMapper : ISalaMapper
    {
        public async Task<Response.Sala> GetSalaResponse(Sala sala)
        {
            return new Response.Sala
            {
                id = sala.SalaId,
                nombre = sala.Nombre,
                capacidad = sala.Capacidad,
            };
        }
    }
}
