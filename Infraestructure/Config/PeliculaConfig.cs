using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> entityBuilder)
        {
            entityBuilder.ToTable("Peliculas");
            entityBuilder.HasKey(p => p.PeliculaId);
            entityBuilder.HasMany<Funcion>(pel => pel.Funciones)
                .WithOne(fun => fun.Pelicula)
                .HasForeignKey(fun => fun.PeliculaId)
                .IsRequired(false);
            entityBuilder.Property(pel => pel.Titulo)
                .HasMaxLength(50)
                .IsRequired();
            entityBuilder.Property(pel => pel.Sinopsis)
                .HasMaxLength(1000)
                .IsRequired();
            entityBuilder.Property(pel => pel.Poster)
                .HasMaxLength(200)
                .IsRequired();
            entityBuilder.Property(pel => pel.Trailer)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
