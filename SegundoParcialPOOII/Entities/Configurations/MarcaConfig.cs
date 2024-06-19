using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SegundoParcialPOOII.Entities.Configurations
{
    
    public class MarcaConfig : IEntityTypeConfiguration<MarcaEntity>
    {
        public void Configure(EntityTypeBuilder<MarcaEntity> builder)
        {
            builder.Property(j=>j.Nombre).HasMaxLength(100);
            builder.Property(j=>j.Nombre).IsRequired();
            builder.Property(j=>j.Codigo).IsRequired();
        }

    }
    
}