using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data
{
    public class SalasData : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.HasData(
            new Sala { SalaId = 1, Nombre = "Sala 1", Capacidad = 5 },
            new Sala { SalaId = 2, Nombre = "Sala 2", Capacidad = 15 },
            new Sala { SalaId = 3, Nombre = "Sala 3", Capacidad = 35 }
            );
        }
    }
}
