using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand _command;
        private readonly ITicketQuery _query;
        private readonly IFuncionService _funcionService;
        private readonly ITicketMapper _ticketMapper;

        public TicketService(ITicketCommand ticketCommand, ITicketQuery ticketQuery, IFuncionService FuncionService, ITicketMapper ticketMapper)
        {
            _command = ticketCommand;
            _query = ticketQuery;
            _funcionService = FuncionService;
            _ticketMapper = ticketMapper;
        }
        public async Task<TicketResponse> createTicket(int funcionId, TicketRequest ticketRequest)
        {
            try
            {
                if (!int.TryParse(funcionId.ToString(), out funcionId)) { throw new ExceptionSintaxError("Formato inválido para el ID, pruebe con un entero"); }
                if (ticketRequest.cantidad < 1) { throw new ExceptionBadRequest("La cantidad no puede ser 0 o negativa"); }
                Funcion unaFuncion = await _funcionService.GetFuncionById(funcionId);
                if (unaFuncion == null) { throw new ExceptionNotFound("Id de función inexistente"); }
                List<Guid> ticketsIds = new();
                if (ticketRequest.cantidad + unaFuncion.Tickets.Count() <= unaFuncion.Sala.Capacidad)
                {
                    for (int i = 0; i < ticketRequest.cantidad; i++)
                    {
                        Ticket unTicket = new Ticket
                        {
                            FuncionId = funcionId,
                            Usuario = ticketRequest.usuario,

                        };
                        Guid idTicket = await _command.RegisterTicket(unTicket);
                        ticketsIds.Add(idTicket);

                    }
                    return await _ticketMapper.GenerateTicketResponse(await _query.GetTicketById(ticketsIds[0]), ticketsIds);
                }
                else
                {
                    throw new Conflict("No hay suficientes tickets disponibles, quedan disponibles: " + (unaFuncion.Sala.Capacidad - unaFuncion.Tickets.Count()));
                }

            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la creación del ticket: " + ex.Message);
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + ex.Message);
            }
            catch (ExceptionBadRequest ex)
            {
                throw new ExceptionBadRequest("Error en el pedido: " + ex);
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en el pedido: " + ex);
            }

        }
    }
}

