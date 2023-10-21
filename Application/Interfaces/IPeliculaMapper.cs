using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPeliculaMapper
    {
        Task<PeliculaResponse> GeneratePeliculaResponse(Pelicula unaPelicula);
        Task<PeliculaGetResponse> GeneratePeliculaGetResponse(Pelicula pelicula);
    }
}
