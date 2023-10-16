using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionCommand
    {
        Task<int> InsertFuncion(Funcion funcion);
        Task<Funcion> DeleteFuncion(Funcion funcion);
    }
}
