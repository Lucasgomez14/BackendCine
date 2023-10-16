namespace Application.Response
{
    public class PeliculaGetResponse
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public Genero genero { get; set; }
    }
}
