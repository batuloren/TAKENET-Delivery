using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Configurations
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            entity.ToTable("Customers");

            entity.HasKey(e => e.id);

            entity.Property(e => e.id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Ad)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Soyad)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Telefon)
                  .IsRequired()
                  .HasMaxLength(30);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.AktifMi)
                  .IsRequired()
                  .HasColumnType("bit")
                  .HasDefaultValue(true);

            entity.Ignore("created");
        }
    }
}
