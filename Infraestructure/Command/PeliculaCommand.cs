using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineBD _context;

        public PeliculaCommand(CineBD DBContext)
        {
            _context = DBContext;
        }
        public async Task<Pelicula> UpdatePelicula(int peliculaId, PeliculaRequest unaPelicula)
        {
            try
            {
                var peliculaToUpdate = await _context.Peliculas.FirstOrDefaultAsync(p => p.PeliculaId == peliculaId);
                peliculaToUpdate.Titulo = unaPelicula.titulo;
                peliculaToUpdate.Trailer = unaPelicula.trailer;
                peliculaToUpdate.Sinopsis = unaPelicula.sinopsis;
                peliculaToUpdate.GeneroId = unaPelicula.genero;
                await _context.SaveChangesAsync();
                return peliculaToUpdate;

            }
            catch (DbUpdateException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }
    }


}
