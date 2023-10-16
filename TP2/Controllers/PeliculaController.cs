using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace TP2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeliculaController : Controller
    {
        private readonly IPeliculaService _service;


        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(PeliculaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetPeliculaById(int Id)
        {
            try
            {
                var result = await _service.GetPeliculaById(Id);
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

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(PeliculaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> UpdatePeliculaById(int Id, PeliculaRequest peliculaRequest)
        {
            try
            {
                var result = await _service.UpdatePelicula(Id, peliculaRequest);
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
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }




    }
}
