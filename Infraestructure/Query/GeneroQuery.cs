using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly CineBD _context;

        public GeneroQuery(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<List<Genero>> GetAllGeneros()
        {
            try
            {
                List<Genero> todosLosGeneros = _context.Generos
                .ToList();

                return todosLosGeneros;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema al obtener funciones");
            }
        }
    }
}
