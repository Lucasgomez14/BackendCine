using Domain.Entities;
using Infraestructure.Config;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class CineBD : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public CineBD(DbContextOptions<CineBD> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionConfig());

            modelBuilder.ApplyConfiguration(new GeneroConfig());
            modelBuilder.ApplyConfiguration(new GenerosData());

            modelBuilder.ApplyConfiguration(new PeliculaConfig());
            modelBuilder.ApplyConfiguration(new PeliculasData());

            modelBuilder.ApplyConfiguration(new SalaConfig());
            modelBuilder.ApplyConfiguration(new SalasData());

            modelBuilder.ApplyConfiguration(new TicketConfig());
        }
    }
}
