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
                .IsRequired();
            entityBuilder.Property(pel => pel.Titulo)
                .HasMaxLength(50)
                .IsRequired();
            entityBuilder.Property(pel => pel.Sinopsis)
                .HasMaxLength(255)
                .IsRequired();
            entityBuilder.Property(pel => pel.Poster)
                .HasMaxLength(100)
                .IsRequired();
            entityBuilder.Property(pel => pel.Trailer)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
