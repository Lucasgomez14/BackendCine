using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFuncionService
    {
        Task<FuncionResponse> RegisterFuncion(FuncionRequest request);
        Task<List<FuncionGetResponse>> GetFuncionesByTitleDateOrCategory(string? date, string? title, int category);

        Task<Funcion> GetFuncionById(int funcionId);
        Task<FuncionResponse> GetFuncionResponseById(int funcionId);
        Task<FuncionDelete> DeleteFuncion(int funcionId);
        Task<CantidadTicketResponse> GetCantidadTickets(int funcionId);

    }
}
