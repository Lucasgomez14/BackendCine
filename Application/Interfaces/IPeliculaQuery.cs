using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPeliculaQuery
    {
        Task<Pelicula> GetPeliculaById(int peliculaId);
        Task<List<Pelicula>> GetAllPeliculas();
    }
}
