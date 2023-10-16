namespace Domain.Entities
{
    public class Funcion
    {
        public int FuncionId { get; set; }

        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
