namespace Application.Response
{
    public class TicketResponse
    {
        public List<Guid> tickets { get; set; }
        public FuncionGetResponse funcion { get; set; }
        public string usuario { get; set; }
    }
}
