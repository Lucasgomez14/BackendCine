using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPeliculaCommand
    {
        Task<Pelicula> UpdatePelicula(int peliculaId, PeliculaRequest unaPelicula);
    }
}
