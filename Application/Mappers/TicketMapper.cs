using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class TicketMapper: ITicketMapper
    {
        private readonly IPeliculaMapper _peliculaMapper;
        private readonly ISalaMapper _salaMapper;

        public TicketMapper (IPeliculaMapper peliculaMapper, ISalaMapper salaMapper)
        {
            _peliculaMapper = peliculaMapper;
            _salaMapper = salaMapper;
        }
    
        public async Task<TicketResponse> GenerateTicketResponse(Ticket unTicket, List<Guid> listaIds)
        {
            return new TicketResponse
            {
                tickets = listaIds,
                funcion = new FuncionGetResponse
                {
                    funcionId = unTicket.Funcion.FuncionId,
                    pelicula = await _peliculaMapper.GeneratePeliculaGetResponse(unTicket.Funcion.Pelicula),
                    //pelicula = new PeliculaGetResponse
                    //{
                    //    peliculaId = unTicket.Funcion.Pelicula.PeliculaId,
                    //    titulo = unTicket.Funcion.Pelicula.Titulo,
                    //    poster = unTicket.Funcion.Pelicula.Poster,
                    //    genero = new Response.Genero
                    //    {
                    //        id = unTicket.Funcion.Pelicula.Genero.GeneroId,
                    //        nombre = unTicket.Funcion.Pelicula.Genero.Nombre,
                    //    },
                    //},
                    sala = await _salaMapper.GetSalaResponse(unTicket.Funcion.Sala),
                    //sala = new Response.Sala
                    //{
                    //    id = unTicket.Funcion.Sala.SalaId,
                    //    nombre = unTicket.Funcion.Sala.Nombre,
                    //    capacidad = unTicket.Funcion.Sala.Capacidad,
                    //},
                    fecha = unTicket.Funcion.Fecha.ToString("dd-MM-yyyy"),
                    horario = unTicket.Funcion.Horario.ToString("hh\\:mm")
                },
                usuario = unTicket.Usuario,
            };
        }

        public async Task<CantidadTicketResponse> GetCantidadTicketResponse (int capacidad, int ticketCount)
        {
            return new CantidadTicketResponse
            {
                cantidad = capacidad - ticketCount,
            };
        }
    }
}
