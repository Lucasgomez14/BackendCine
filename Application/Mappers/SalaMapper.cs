using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class SalaMapper: ISalaMapper
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
