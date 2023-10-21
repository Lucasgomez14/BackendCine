using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entityBuilder)
        {
            // entityBuilder.HasKey(t => new { t.TicketId, t.FuncionId });
            entityBuilder.ToTable("Tickets");
            entityBuilder.HasKey(f => f.TicketId);
            entityBuilder.Property(tick => tick.Usuario)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
