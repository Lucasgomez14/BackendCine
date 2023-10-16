using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class GeneroMapper: IGeneroMapper
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
