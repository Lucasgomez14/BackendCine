using Application.Interfaces;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class FuncionMapper : IFuncionMapper
    {
        private readonly ISalaMapper _salaMapper;
        private readonly IPeliculaMapper _peliculaMapper;
        public FuncionMapper(IPeliculaMapper peliculaMapper, ISalaMapper salaMapper)
        {
            _salaMapper = salaMapper;
            _peliculaMapper = peliculaMapper;
        }
        public async Task<FuncionResponse> GenerateFuncionResponse(Funcion newFuncion)
        {
            return new FuncionResponse
            {
                funcionId = newFuncion.FuncionId,
                pelicula = await _peliculaMapper.GeneratePeliculaGetResponse(newFuncion.Pelicula),
                sala = await _salaMapper.GetSalaResponse(newFuncion.Sala),
                fecha = newFuncion.Fecha.ToString("dd-MM-yyyy"),
                horario = newFuncion.Horario.ToString("hh\\:mm"),

            };
        }

        public async Task<FuncionGetResponse> GenerateFuncionGetResponse(Funcion newFuncion)
        {
            return new FuncionGetResponse
            {
                funcionId = newFuncion.FuncionId,
                pelicula = await _peliculaMapper.GeneratePeliculaGetResponse(newFuncion.Pelicula),
                sala = await _salaMapper.GetSalaResponse(newFuncion.Sala),
                fecha = newFuncion.Fecha.ToString("dd-MM-yyyy"),
                horario = newFuncion.Horario.ToString("hh\\:mm")
            };
        }

        public async Task<List<FuncionGetResponse>> GenerateListFuncionGetResponse(List<Funcion> funciones)
        {
            List<FuncionGetResponse> funcionesResponse = new();
            foreach (Funcion funcion in funciones)
            {
                funcionesResponse.Add(await GenerateFuncionGetResponse(funcion));
            }
            return funcionesResponse;
        }

        public async Task<FuncionDelete> GenerateFuncionDelete(Funcion newFuncion)
        {
            return new FuncionDelete
            {
                funcionId = newFuncion.FuncionId,
                fecha = newFuncion.Fecha.ToString("dd-MM-yyyy"),
                horario = newFuncion.Horario.ToString("hh\\:mm")
            };
        }

        public async Task<List<FuncionDelete>> GenerateDeleteFunciones(ICollection<Funcion> listaFunciones)
        {
            List<FuncionDelete> funcionesDelete = new();
            foreach (Funcion unaFuncion in listaFunciones)
            {
                funcionesDelete.Add(await GenerateFuncionDelete(unaFuncion));

            }
            return funcionesDelete;
        }
    }
}
