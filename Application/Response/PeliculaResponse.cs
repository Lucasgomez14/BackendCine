namespace Application.Response
{
    public class PeliculaResponse
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; }
        public string poster { get; set; }
        public string trailer { get; set; }
        public string sinopsis { get; set; }
        public Genero genero { get; set; }
        public List<FuncionDelete> funciones { get; set; }
    }
}
