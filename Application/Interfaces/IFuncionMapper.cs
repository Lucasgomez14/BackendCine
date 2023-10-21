using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionMapper
    {
        Task<FuncionGetResponse> GenerateFuncionGetResponse(Funcion newFuncion);
        Task<FuncionResponse> GenerateFuncionResponse(Funcion newFuncion);
        Task<FuncionDelete> GenerateFuncionDelete(Funcion newFuncion);
        Task<List<FuncionDelete>> GenerateDeleteFunciones(ICollection<Funcion> listaFunciones);
        Task<List<FuncionGetResponse>> GenerateListFuncionGetResponse(List<Funcion> funciones);
    }
}
