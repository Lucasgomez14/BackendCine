using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
