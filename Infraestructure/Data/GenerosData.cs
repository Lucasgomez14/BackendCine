using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data
{
    public class GenerosData : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasData(
            new Genero { GeneroId = 1, Nombre = "Acción" },
            new Genero { GeneroId = 2, Nombre = "Aventura" },
            new Genero { GeneroId = 3, Nombre = "Ciencia" },
            new Genero { GeneroId = 4, Nombre = "Ficción" },
            new Genero { GeneroId = 5, Nombre = "Comedia" },
            new Genero { GeneroId = 6, Nombre = "Documental" },
            new Genero { GeneroId = 7, Nombre = "Drama" },
            new Genero { GeneroId = 8, Nombre = "Fantasía" },
            new Genero { GeneroId = 9, Nombre = "Musical" },
            new Genero { GeneroId = 10, Nombre = "Suspense" },
            new Genero { GeneroId = 11, Nombre = "Terror" }
            );
        }
    }
}
