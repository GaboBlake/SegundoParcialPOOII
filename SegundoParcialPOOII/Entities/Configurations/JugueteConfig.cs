using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SegundoParcialPOOII.Entities.Configurations
{
    public class JugueteConfig : IEntityTypeConfiguration<JugueteEntity>
    {
        public void Configure(EntityTypeBuilder<JugueteEntity> builder)
        {
            builder.Property(j=>j.Nombre).HasMaxLength(100);
            builder.Property(j=>j.Nombre).IsRequired();
            builder.Property(j=>j.Precio).IsRequired();
        }
    }
}