using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Configurations
{
    public class DriverMap : IEntityTypeConfiguration<Drivers>
    {
        public void Configure(EntityTypeBuilder<Drivers> entity)
        {
            entity.HasKey(e => e.id);

            entity.Property(e => e.id)
                  .IsRequired()
                  .HasDefaultValueSql("(newId())");

            entity.Property(e => e.Ad)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Soyad)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Telefon)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.AktifMi)
                  .IsRequired()
                  .HasColumnType("bit")
                  .HasDefaultValue(true);
        }
    }
}
