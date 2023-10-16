using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace TP2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionController : Controller
    {
        private readonly IFuncionService _serviceFuncion;
        private readonly ITicketService _serviceTicket;


        public FuncionController(IFuncionService service, ITicketService serviceTicket)
        {
            _serviceFuncion = service;
            _serviceTicket = serviceTicket;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FuncionGetResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public async Task<IActionResult> GetPeliculaByfilter(string? fecha, string? titulo, int genero)
        {
            try
            {
                var result = await _serviceFuncion.GetFuncionesByTitleDateOrCategory(fecha, titulo, genero);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(FuncionResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> RegisterFuncion(FuncionRequest request)
        {
            try
            {
                var result = await _serviceFuncion.RegisterFuncion(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(FuncionResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetFuncionById(int Id)
        {
            try
            {
                var result = await _serviceFuncion.GetFuncionResponseById(Id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(FuncionDelete), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> DeleteFuncion(int Id)
        {
            try
            {
                var result = await _serviceFuncion.DeleteFuncion(Id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpGet("{Id}/tickets")]
        [ProducesResponseType(typeof(CantidadTicketResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetTicketById(int Id)
        {
            try
            {
                var result = await _serviceFuncion.GetCantidadTickets(Id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }

        }

        [HttpPost("{Id}/tickets")]
        [ProducesResponseType(typeof(TicketResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> RegisterTicket(int Id, TicketRequest request)
        {
            try
            {
                var result = await _serviceTicket.createTicket(Id, request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
        }


    }
}
