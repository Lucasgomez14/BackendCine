using Application.Response;

namespace Application.Interfaces
{
    public interface IGeneroMapper
    {
        Task<Genero> GetGeneroMapper(Domain.Entities.Genero unGenero);
    }
}
