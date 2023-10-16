using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class SalaConfig : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> entityBuilder)
        {
            entityBuilder.ToTable("Salas");
            entityBuilder.HasKey(s => s.SalaId);
            entityBuilder.HasMany<Funcion>(sala => sala.Funciones)
                .WithOne(fun => fun.Sala)
                .HasForeignKey(fun => fun.SalaId)
                .IsRequired(false);

            entityBuilder.Property(sala => sala.Nombre)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
