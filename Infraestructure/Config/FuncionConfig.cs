using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class FuncionConfig : IEntityTypeConfiguration<Funcion>
    {
        public void Configure(EntityTypeBuilder<Funcion> entityBuilder)
        {
            entityBuilder.ToTable("Funciones");
            entityBuilder.HasKey(f => f.FuncionId);
            entityBuilder.HasMany<Ticket>(fun => fun.Tickets)
                .WithOne(tick => tick.Funcion)
                .HasForeignKey(tick => tick.FuncionId)
                .IsRequired(false);
        }
    }
}
