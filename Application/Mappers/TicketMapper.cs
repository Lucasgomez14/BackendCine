using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TicketMapper : ITicketMapper
    {
        private readonly IPeliculaMapper _peliculaMapper;
        private readonly ISalaMapper _salaMapper;

        public TicketMapper(IPeliculaMapper peliculaMapper, ISalaMapper salaMapper)
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
                    sala = await _salaMapper.GetSalaResponse(unTicket.Funcion.Sala),
                    fecha = unTicket.Funcion.Fecha.ToString("dd-MM-yyyy"),
                    horario = unTicket.Funcion.Horario.ToString("hh\\:mm")
                },
                usuario = unTicket.Usuario,
            };
        }

        public async Task<CantidadTicketResponse> GetCantidadTicketResponse(int capacidad, int ticketCount)
        {
            return new CantidadTicketResponse
            {
                cantidad = capacidad - ticketCount,
            };
        }
    }
}
