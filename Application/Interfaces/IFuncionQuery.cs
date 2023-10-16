using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionQuery
    {
        Task<Funcion> GetFuncionById(int id);
        Task<List<Funcion>> GetFuncionesByTitle(string title);
        Task<List<Funcion>> GetFuncionesByDate(DateTime fecha);
        Task<List<Funcion>> GetAllFunciones();

        Task<List<Funcion>> GetFuncionByCategory(int category);
    }
}
