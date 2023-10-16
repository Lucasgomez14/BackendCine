using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IPeliculaService
    {
        public Task<PeliculaResponse> GetPeliculaById(int peliculaId);
        public Task<PeliculaResponse> UpdatePelicula(int peliculaId, PeliculaRequest peliculaRequest);
    }
}
