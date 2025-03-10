using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDSPG.API.Domain.Entity;

namespace TDSPG.API.Infrastructure.Mappings
{
    public class EstablishmentMapping : IEntityTypeConfiguration<Establishment>
    {
        public void Configure(EntityTypeBuilder<Establishment> builder)
        {
            // caso de refatoração - nome da tabela é outro e nao podemos alterar
            builder.ToTable("Establishment");

            builder.HasKey("EstablishmentId");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Document)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
