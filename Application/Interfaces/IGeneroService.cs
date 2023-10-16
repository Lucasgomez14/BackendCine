using Genero = Domain.Entities.Genero;

namespace Application.Interfaces
{
    public interface IGeneroService
    {
        Task<List<Genero>> AllGeneros();
    }
}
