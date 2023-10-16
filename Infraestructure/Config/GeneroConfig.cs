using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> entityBuilder)
        {
            entityBuilder.ToTable("Generos");
            entityBuilder.HasKey(g => g.GeneroId);
            entityBuilder.HasMany<Pelicula>(gen => gen.Peliculas)
                .WithOne(pel => pel.Genero)
                .HasForeignKey(pel => pel.GeneroId)
                .IsRequired(false);
            entityBuilder.Property(gen => gen.Nombre)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
