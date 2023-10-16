using Genero = Domain.Entities.Genero;

namespace Application.Interfaces
{
    public interface IGeneroQuery
    {
        Task<List<Genero>> GetAllGeneros();
    }
}
