using Application.Exceptions;
using Application.Interfaces;
using Application.Mappers;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaQuery _query;
        private readonly IPeliculaCommand _command;
        private readonly IGeneroService _serviceGenero;
        private readonly IPeliculaMapper _peliculaMapper;

        public PeliculaService(IPeliculaQuery peliculaQuery, IPeliculaCommand peliculaCommand, IGeneroService generoService, IPeliculaMapper peliculaMapper)
        {
            _query = peliculaQuery;
            _command = peliculaCommand;
            _serviceGenero = generoService;
            _peliculaMapper = peliculaMapper;
        }
        public async Task<PeliculaResponse> GetPeliculaById(int peliculaId)
        {
            try
            {
                if (!VerifyInt(peliculaId)) { throw new ExceptionSintaxError(); }
                Pelicula unaPelicula = await _query.GetPeliculaById(peliculaId);
                if (unaPelicula != null)
                {
                    return await _peliculaMapper.GeneratePeliculaResponse(unaPelicula);
                }
                else
                {
                    throw new ExceptionNotFound("No se encontró la pelicula solicitada");
                }
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }

        }
        public async Task<PeliculaResponse> UpdatePelicula(int peliculaId, PeliculaRequest peliculaRequest)
        {
            try
            {
                if (!VerifyInt(peliculaId)) { throw new ExceptionSintaxError("Formato erróneo para el ID, pruebe con un entero"); }
                peliculaRequest.titulo = char.ToUpper(peliculaRequest.titulo[0]) + peliculaRequest.titulo.Substring(1);
                Pelicula unaPelicula = await _query.GetPeliculaById(peliculaId);
                if (unaPelicula != null)
                {
                    if (await VerifySameName(peliculaRequest.titulo, peliculaId)) { throw new Conflict("Ya existe una película con ese nombre"); }
                    if (!await VerifyGenero(peliculaRequest.genero)) { throw new ExceptionNotFound("No existe ningún género con ese ID"); }
                    unaPelicula = await _command.UpdatePelicula(peliculaId, peliculaRequest);
                    return await _peliculaMapper.GeneratePeliculaResponse(unaPelicula);

                }
                else
                {
                    { throw new ExceptionNotFound("No existe ninguna película con ese ID"); }
                }
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error: " + ex.Message);
            }

        }

        //Private methods

        //extras
        private bool VerifyInt(int entero)
        {
            return (int.TryParse(entero.ToString(), out entero));
        }

        private async Task<bool> VerifySameName(string tituloPelicula, int peliculaId)
        {
            List<Pelicula> listaPeliculas = await _query.GetAllPeliculas();
            return (listaPeliculas.Any(p => p.Titulo.Equals(tituloPelicula) && p.PeliculaId != peliculaId));
        }

        private async Task<bool> VerifyGenero(int generoId)
        {
            List<Domain.Entities.Genero> listaGeneros = await _serviceGenero.AllGeneros();
            return (listaGeneros.Any(g => g.GeneroId == generoId));

        }
    }
}
