using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPeliculaMapper
    {
        Task<PeliculaResponse> GeneratePeliculaResponse(Pelicula unaPelicula);
        Task<PeliculaGetResponse> GeneratePeliculaGetResponse(Pelicula pelicula);
    }
}
