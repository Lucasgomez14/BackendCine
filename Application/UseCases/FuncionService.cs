using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionQuery _query;
        private readonly IFuncionCommand _command;
        private readonly IPeliculaService _peliculaService;
        private readonly ISalaService _salaService;
        private readonly IFuncionMapper _funcionMapper;
        private readonly ITicketMapper _ticketMapper;

        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IPeliculaService peliculaService, ISalaService salaService, IFuncionMapper funcionMapper, ITicketMapper ticketMapper)
        {
            _command = funcionCommand;
            _query = funcionQuery;
            _peliculaService = peliculaService;
            _salaService = salaService;
            _funcionMapper = funcionMapper;
            _ticketMapper = ticketMapper;
        }

        public async Task<FuncionResponse> RegisterFuncion(FuncionRequest request)
        {
            try
            {
                if (await _peliculaService.GetPeliculaById(request.pelicula) == null) { throw new ExceptionNotFound("No existe la película"); }
                if (await _salaService.ExistSala(request.sala)) { throw new ExceptionNotFound("No existe la sala"); }
                if (!DateTime.TryParse(request.fecha, out DateTime date)) { throw new ExceptionSintaxError("Formato érroneo para la fecha, pruebe ingresando dd/mm/aaaa"); }
                if (!TimeSpan.TryParse(request.horario, out TimeSpan tiempo) || tiempo.TotalHours > 24) { throw new ExceptionSintaxError("Formato érroneo para el horario, ingrese desde las 00:00 a 24:00Hs"); }
                if (!await VerifyIfSalaisEmpty(date, tiempo, request.sala)) { throw new Conflict("La sala ya está ocupada en esa fecha y horario!"); }
                var newFuncion = new Funcion
                {
                    PeliculaId = request.pelicula,
                    SalaId = request.sala,
                    Fecha = date,
                    Horario = tiempo,
                    Tickets = new List<Ticket>(),
                };
                int funcionId = await _command.InsertFuncion(newFuncion);
                newFuncion = await _query.GetFuncionById(funcionId);
                return await _funcionMapper.GenerateFuncionResponse(newFuncion);

            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error: " + ex.Message);
            }
        }

        public async Task<FuncionDelete> DeleteFuncion(int funcionId)
        {
            try
            {
                if (!VerifyInt(funcionId)) { throw new ExceptionSintaxError(); }
                Funcion unaFuncion = await _query.GetFuncionById(funcionId);
                if (unaFuncion != null)
                {
                    if (unaFuncion.Tickets.Count() != 0) { throw new Conflict("Existen tickets registrados a la función"); }
                    unaFuncion = await _command.DeleteFuncion(unaFuncion);
                    return await _funcionMapper.GenerateFuncionDelete(unaFuncion);
                }
                else
                {
                    throw new ExceptionNotFound("No existe ninguna funcion con ese ID");
                }
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Formato erróneo para el ID, pruebe con un entero");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error al remover la función: " + ex.Message);
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error al remover la función: " + ex.Message);
            }
        }

        public async Task<List<FuncionGetResponse>> GetFuncionesByTitleDateOrCategory(string? fecha, string? title, int category)
        {
            try
            {
                DateTime date;
                List<Funcion> funcionesByDate = new();
                List<Funcion> funcionesByTitle = new();
                List<Funcion> listFunciones = new();
                List<Funcion> funcionesByCategory = new();

                if (title == null && fecha == null && category == 0)
                {
                    listFunciones = await _query.GetAllFunciones();
                }
                if (fecha != null)
                {
                    if (!DateTime.TryParse(fecha, out date)) { throw new ExceptionSintaxError("Formato érroneo para la fecha"); }

                    listFunciones = await _query.GetFuncionesByDate(date);

                    if (listFunciones.Count() == 0 && title != "")
                    { return await _funcionMapper.GenerateListFuncionGetResponse(listFunciones); }
                }
                if (title != null)
                {
                    funcionesByTitle = await _query.GetFuncionesByTitle(title);
                    if (listFunciones.Count() > 0)
                    { listFunciones = GroupData(listFunciones, funcionesByTitle); }
                    else
                    { listFunciones = funcionesByTitle; }
                }
                if (category != 0)
                {
                    funcionesByCategory = await _query.GetFuncionByCategory(category);
                    if (listFunciones.Count() > 0)
                    {
                        listFunciones = GroupData(listFunciones, funcionesByCategory);
                    }
                    else
                    {
                        listFunciones = funcionesByCategory;
                    }

                }
                return await _funcionMapper.GenerateListFuncionGetResponse(listFunciones);
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis ingresada para la fecha: " + ex.Message);
            }
        }

        public async Task<FuncionResponse> GetFuncionResponseById(int funcionId)
        {
            try
            {
                if (!VerifyInt(funcionId)) { throw new ExceptionSintaxError(); }
                Funcion unaFuncion = await GetFuncionById(funcionId);
                return await _funcionMapper.GenerateFuncionResponse(unaFuncion);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound(ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del ID, pruebe con un entero");
            }


        }

        public async Task<Funcion> GetFuncionById(int funcionId)
        {
            try
            {
                Funcion unaFuncion = await _query.GetFuncionById(funcionId);
                if (unaFuncion != null)
                {
                    return unaFuncion;
                }
                else
                {
                    throw new ExceptionNotFound("No existe funcion con ese ID");
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la búsqueda: " + ex.Message);
            }
        }

        public async Task<CantidadTicketResponse> GetCantidadTickets(int funcionId)
        {
            try
            {
                if (!VerifyInt(funcionId)) { throw new ExceptionSintaxError("Formato erróneo para el ID, pruebe con un entero"); }
                Funcion unaFuncion = await _query.GetFuncionById(funcionId);
                if (unaFuncion != null)
                {
                    return await _ticketMapper.GetCantidadTicketResponse(unaFuncion.Sala.Capacidad, unaFuncion.Tickets.Count());
                    //return new CantidadTicketResponse
                    //{
                    //    cantidad = unaFuncion.Sala.Capacidad - unaFuncion.Tickets.Count(),
                    //};
                }
                else
                {
                    throw new ExceptionNotFound("No se encontró ninguna función con ese ID");
                }
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la búsqueda: " + ex.Message);
            }

        }

        //Privates methods

        //List
        private List<Funcion> GroupData(List<Funcion> principalList, List<Funcion> secundaryList)
        {
            List<Funcion> unitedList = new();
            foreach (Funcion unaFuncion in secundaryList)
            {
                if (principalList.Any(f => f.FuncionId == unaFuncion.FuncionId && f.Fecha.Date == unaFuncion.Fecha.Date && f.Pelicula.GeneroId == unaFuncion.Pelicula.GeneroId))
                { unitedList.Add(unaFuncion); }
            }
            return unitedList;
        }

        //Extras
        private async Task<bool> VerifyIfSalaisEmpty(DateTime fecha, TimeSpan horario, int salaId)
        {
            List<Funcion> listFunciones = await _query.GetAllFunciones();
            TimeSpan LapsoHorario = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30);
            return !(listFunciones.Any(f =>
               (f.SalaId == salaId && f.Fecha == fecha) &&
               (Math.Abs((horario - f.Horario).Ticks) <= LapsoHorario.Ticks ||
                Math.Abs((f.Horario - horario).Ticks) <= LapsoHorario.Ticks)));

        }
        private bool VerifyInt(int entero)
        {
            return (int.TryParse(entero.ToString(), out entero));
        }


    }
}
