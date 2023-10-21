namespace Application.Interfaces
{
    public interface ISalaMapper
    {
        Task<Response.Sala> GetSalaResponse(Domain.Entities.Sala sala);
    }
}
