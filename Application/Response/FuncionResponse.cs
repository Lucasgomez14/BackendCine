namespace Application.Response
{
    public class FuncionResponse
    {
        public int funcionId { get; set; }
        public PeliculaGetResponse pelicula { get; set; }
        public Sala sala { get; set; }
        public string fecha { get; set; }
        public string horario { get; set; }
    }
}
