using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Configurations
{
    public class StatusMap : IEntityTypeConfiguration<Statuses>
    {
        public void Configure(EntityTypeBuilder<Statuses> entity) 
        {
            entity.HasKey(e => e.id);

            entity.Property(e => e.id)
                 .IsRequired()
                 .HasDefaultValueSql("newId()");

            entity.Property(e => e.Durum)
                  .HasMaxLength(50);

            entity.Property(e => e.StatusCode)
                  .IsRequired();

            entity.Property(e => e.AktifMi)
                  .IsRequired()
                  .HasColumnType("bit")
                  .HasDefaultValue(true);
        }
    }
}
