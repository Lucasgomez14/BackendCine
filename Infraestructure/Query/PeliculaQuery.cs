using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineBD _context;

        public PeliculaQuery(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<Pelicula> GetPeliculaById(int peliculaId)
        {
            try
            {
                return await _context.Peliculas
                            .Include(p => p.Genero)
                            .Include(p => p.Funciones)
                            .SingleOrDefaultAsync(p => p.PeliculaId == peliculaId);
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema al obtener las películas");
            }

        }

        public async Task<List<Pelicula>> GetAllPeliculas()
        {
            try
            {
                List<Pelicula> todasLasFunciones = _context.Peliculas
                .Include(p => p.Genero)
                .Include(p => p.Funciones)
                .ToList();

                return todasLasFunciones;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos: Problema al obtener las películas");
            }
        }
    }
}
